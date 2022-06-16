using System.Linq.Expressions;
using BusinessLogicValidatorInterface;
using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServicesInterface;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class TransactionLogicTest
    {
        private Transaction _transaction = new();

        private Mock<IBusinessValidator<Transaction>> _transactionValidatorMock;
        private Mock<INotificationService> _notificationServiceMock;
        private Mock<IRepository<Transaction>> _transactionRepositoryMock;
        private Mock<IRepository<CoinAccount>> _accountRepositoryMock;
        private Mock<IRepository<Coin>> _coinRepositoryMock;
        private Mock<IRepository<User>> _userRepositoryMock;
        private Mock<INotificationService> _notificationService;
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
                CoinId = 1,
                WalletAddress = "some-wallet-address"
            };

            _transactionValidatorMock = new Mock<IBusinessValidator<Transaction>>(MockBehavior.Strict);
            _notificationServiceMock = new Mock<INotificationService>(MockBehavior.Strict);

            _transactionRepositoryMock = new Mock<IRepository<Transaction>>(MockBehavior.Strict);
            _accountRepositoryMock = new Mock<IRepository<CoinAccount>>(MockBehavior.Strict);
            _userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            _coinRepositoryMock = new Mock<IRepository<Coin>>(MockBehavior.Strict);

            var unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWorkMock.Setup(m => m.GetRepository<Transaction>()).Returns(_transactionRepositoryMock.Object);
            unitOfWorkMock.Setup(m => m.GetRepository<CoinAccount>()).Returns(_accountRepositoryMock.Object);
            unitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(_userRepositoryMock.Object);
            unitOfWorkMock.Setup(m => m.GetRepository<Coin>()).Returns(_coinRepositoryMock.Object);

            _transactionLogic = new TransactionLogic(
                _transactionValidatorMock.Object,   
                _notificationServiceMock.Object,
                unitOfWorkMock.Object);
        }

        [TestMethod]
        public async Task AddTransaction()
        {
            CoinAccount _coinAccount = new()
            {
                Id = 1,
                Balance = 10,
                UserId = 1,
                CoinId = 1
            };

            Coin _coin = new()
            {
                Id = 1,
                LongName = "Crypto",
                ShortName = "CRP",
                Icon = "long-string-base64"
            };

            User _user = new()
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe",
                Email = "john.doe@test.com",
                Password = "jd12345",
                WalletAddress = "some-wallet-address",
                Token = "some-token",
                DeviceToken = "some-device-token",
                Image = "some-long-string-base64"
            };

            _transactionValidatorMock.Setup(m => m.CreationValidation(_transaction));
            _transactionValidatorMock.Setup(m => m.ValidateWalletAddress("some-wallet-address"));
            _transactionRepositoryMock.Setup(m => m.InsertAndSave(_transaction));

            _accountRepositoryMock.Setup(m => m.Get(It.IsAny<Expression<Func<CoinAccount, bool>>>(), null, null, false))
                .Returns(_coinAccount);
            _accountRepositoryMock.Setup(m => m.UpdateAndSave(_coinAccount));

            _userRepositoryMock.Setup(m => m.Get(It.IsAny<Expression<Func<User, bool>>>(), null, null, false))
                .Returns(_user);
            _coinRepositoryMock.Setup(m => m.Get(It.IsAny<Expression<Func<Coin, bool>>>(), null, null, false))
                .Returns(_coin);

            _notificationServiceMock.Setup(m => m.SendNotification("some-device-token", "Has recibido 1CRP"))
                .Returns(Task.FromResult(It.IsAny<Task>()));

            await _transactionLogic.Add(_transaction);

            _transactionValidatorMock.VerifyAll();
            _transactionRepositoryMock.VerifyAll();
            _accountRepositoryMock.VerifyAll();
            _coinRepositoryMock.VerifyAll();
            _userRepositoryMock.VerifyAll();
            _notificationServiceMock.VerifyAll();
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

        [TestMethod]
        public void GetAllUserTransactions()
        {
            List<Transaction> mockTransactionsList = new() { _transaction };
            Dictionary<string, string> mockParametros = new()
            {
                { "userid", "1" }
            };

            _userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(true);
            _transactionRepositoryMock.Setup(m => m.GetCollection(
                It.IsAny<Expression<Func<Transaction, bool>>>(),
                null,
                It.IsAny<Func<IQueryable<Transaction>, IOrderedQueryable<Transaction>>>(),
                It.IsAny<Func<IQueryable<Transaction>, IIncludableQueryable<Transaction, object>>>()
                )).Returns(mockTransactionsList);

            IEnumerable<Transaction> returnedTransactions = _transactionLogic.GetCollection(mockParametros);

            _transactionRepositoryMock.VerifyAll();
            Assert.IsTrue((mockTransactionsList).SequenceEqual(returnedTransactions));
        }

        [TestMethod]
        public void GetAllTransactionsNonExistingUser()
        {
            List<Transaction> mockTransactionsList = new() { _transaction };
            Dictionary<string, string> mockParametros = new()
            {
                { "userid", "100" }
            };

            _userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(false);

            string result = "";
            try
            {
                IEnumerable<Transaction> returnedTransactions = _transactionLogic.GetCollection(mockParametros);
            }
            catch (KeyNotFoundException ex)
            {
                result = ex.Message;
            }

            _transactionRepositoryMock.VerifyAll();
            Assert.AreEqual("ID: 100 not found.", result);
        }

        [TestMethod]
        public void GetAllTransactionsWithoutUserIdParam()
        {
            Dictionary<string, string> mockParametros = new()
            {
                { "userid", "" }
            };

            string result = "";
            try
            {
                IEnumerable<Transaction> returnedTransactions = _transactionLogic.GetCollection(mockParametros);
            }
            catch (ArgumentException ex)
            {
                result = ex.Message;
            }

            _transactionRepositoryMock.VerifyAll();
            Assert.AreEqual("Missing user ID on query params.", result);
        }
    }
}