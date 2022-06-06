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
    public class UserTest
    {
        private User _user = new();
        private List<CoinAccount> _coinAccounts = new();

        private Mock<IBusinessValidator<User>> _userValidatorMock;
        private Mock<IRepository<User>> _userRepositoryMock;
        private Mock<IRepository<CoinAccount>> _accountRepositoryMock;
        private UserLogic _userLogic;

        [TestInitialize]
        public void TestSetup()
        {
            _user = new User
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe",
                Email = "john.doe@test.com",
                Password = "testPassword"
            };

            _coinAccounts = new()
            {
                new CoinAccount
                {
                    Balance = 10,
                    Coin = new Coin()
                    {
                        Icon = "Fake Icon",
                        Id = 1,
                        LongName = "Fake Coin",
                        ShortName = "FC"
                    }
                }
            };

            _userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);
            _userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            _accountRepositoryMock = new Mock<IRepository<CoinAccount>>(MockBehavior.Strict);

            var unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(_userRepositoryMock.Object);
            unitOfWorkMock.Setup(m => m.GetRepository<CoinAccount>()).Returns(_accountRepositoryMock.Object);

            _userLogic = new UserLogic(_userValidatorMock.Object, unitOfWorkMock.Object);
        }

        [TestMethod]
        public void AddUser()
        {
            _userValidatorMock.Setup(m => m.CreationValidation(_user));
            _userRepositoryMock.Setup(m => m.InsertAndSave(_user));
            _accountRepositoryMock.Setup(m => m.InsertAndSave(It.IsAny<CoinAccount>()));

            var returnedUser = _userLogic.Add(_user);

            _userValidatorMock.VerifyAll();
            _userRepositoryMock.VerifyAll();
            _accountRepositoryMock.Verify(repository => repository.InsertAndSave(It.IsAny<CoinAccount>()),
                Times.Exactly(3));
            Assert.AreEqual("John", returnedUser.Name);
        }

        [TestMethod]
        public void GetUserById()
        {
            _userValidatorMock.Setup(m => m.ValidateIdentifier(_user.Id));
            _userRepositoryMock.Setup(m => m.Get(It.IsAny<Expression<Func<User, bool>>>(), null, null, false))
                .Returns(_user);

            var returnedUser = _userLogic.Get(_user.Id);

            _userValidatorMock.VerifyAll();
            _userRepositoryMock.VerifyAll();
            Assert.AreEqual("John", returnedUser.Name);
        }

        [TestMethod]
        public void DeleteUser()
        {
            _userValidatorMock.Setup(m => m.ValidateIdentifier(1));
            _userRepositoryMock.Setup(m => m.DeleteByIdAndSave(1));

            _userLogic.Delete(1);

            _userValidatorMock.VerifyAll();
            _userRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void UpdateUser()
        {
            _userValidatorMock.Setup(m => m.ValidateIdentifier(1));
            _userValidatorMock.Setup(m => m.EditionValidation(1, _user));
            _userRepositoryMock.Setup(m => m.UpdateAndSave(_user));
            
            _userLogic.Edit(1, _user);

            _userValidatorMock.VerifyAll();
            _userRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void GetAccountsFromUser()
        {
            _userValidatorMock.Setup(m => m.ValidateIdentifier(1));
            _accountRepositoryMock.Setup(m => m.GetCollection(It.IsAny<Expression<Func<CoinAccount, bool>>?>(), null,
                    null, It.IsAny<Func<IQueryable<CoinAccount>, IIncludableQueryable<CoinAccount, object>>?>()))
                .Returns(_coinAccounts);
            
            var returnedCoinAccounts = _userLogic.GetAccountsFromUser(1);

            _userValidatorMock.VerifyAll();
            _accountRepositoryMock.VerifyAll();
            Assert.AreEqual(_coinAccounts.First(), returnedCoinAccounts.First());
        }
    }
}