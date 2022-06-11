using System.Linq.Expressions;
using BusinessLogicValidatorInterface;
using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class TransactionLogicTest
    {
        private Transaction _transaction = new();

        private Mock<IBusinessValidator<Transaction>> _transactionValidatorMock;
        private Mock<IRepository<Transaction>> _transactionRepositoryMock;
        private Mock<IRepository<CoinAccount>> _accountRepositoryMock;
        private TransactionLogic _transactionLogic;

        [TestInitialize]
        public void TestSetup()
        {
            _transaction = new Transaction
            {
                Id = 1,
                Amount = 1,
                SenderId = 1,
                ReceiverId = 2,
                CoinId = 1
            };

            _transactionValidatorMock = new Mock<IBusinessValidator<Transaction>>(MockBehavior.Strict);

            _transactionRepositoryMock = new Mock<IRepository<Transaction>>(MockBehavior.Strict);
            _accountRepositoryMock = new Mock<IRepository<CoinAccount>>(MockBehavior.Strict);

            var unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWorkMock.Setup(m => m.GetRepository<Transaction>()).Returns(_transactionRepositoryMock.Object);
            unitOfWorkMock.Setup(m => m.GetRepository<CoinAccount>()).Returns(_accountRepositoryMock.Object);

            _transactionLogic = new TransactionLogic(_transactionValidatorMock.Object, unitOfWorkMock.Object);
        }

        [TestMethod]
        public void AddTransaction()
        {
            CoinAccount _coinAccount = new()
            {
                Id = 1,
                Balance = 10,
                UserId = 1,
                CoinId = 1
            };

            _transactionValidatorMock.Setup(m => m.CreationValidation(_transaction));
            _transactionRepositoryMock.Setup(m => m.InsertAndSave(_transaction));
            _accountRepositoryMock.Setup(m => m.Get(It.IsAny<Expression<Func<CoinAccount, bool>>>(), null, null, false))
                .Returns(_coinAccount);

            _accountRepositoryMock.Setup(m => m.UpdateAndSave(_coinAccount));

            _transactionLogic.Add(_transaction);

            _transactionValidatorMock.VerifyAll();
            _transactionRepositoryMock.VerifyAll();
            _accountRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void HandleTransactionAmount()
        {
            CoinAccount _coinAccount = new()
            {
                Id = 1,
                Balance = 10,
                UserId = 1,
                CoinId = 1
            };

            _accountRepositoryMock.Setup(m => m.Get(It.IsAny<Expression<Func<CoinAccount, bool>>>(), null, null, false))
                .Returns(_coinAccount);

            _accountRepositoryMock.Setup(m => m.UpdateAndSave(_coinAccount));

            _transactionLogic.HandleTransactionAmount(_transaction);

            _accountRepositoryMock.VerifyAll();
        }
    }
}