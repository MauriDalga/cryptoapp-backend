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
    public class UserLogicTest
    {
        private User _user = new();

        private Mock<IBusinessValidator<User>> _userValidatorMock;
        private Mock<IRepository<Coin>> _coinRepositoryMock;
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
                Password = "testPassword",
                Image = ""
            };

            _userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);

            _coinRepositoryMock = new Mock<IRepository<Coin>>(MockBehavior.Strict);
            _userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            _accountRepositoryMock = new Mock<IRepository<CoinAccount>>(MockBehavior.Strict);

            var unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWorkMock.Setup(m => m.GetRepository<Coin>()).Returns(_coinRepositoryMock.Object);
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
                Times.Exactly(10));
            Assert.AreEqual("John", returnedUser.Name);
        }

        [TestMethod]
        public void GetUserById()
        {
            _userValidatorMock.Setup(m => m.ValidateIdentifier(_user.Id));
            _userRepositoryMock.Setup(m => m.Get(
                It.IsAny<Expression<Func<User, bool>>>(),
                null,
                It.IsAny<Func<IQueryable<User>, IIncludableQueryable<User, object>>>(),
                false)).Returns(_user);

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
            _userRepositoryMock.Setup(m => m.Get(
                It.IsAny<Expression<Func<User, bool>>>(),
                null,
                It.IsAny<Func<IQueryable<User>, IIncludableQueryable<User, object>>>(),
                false)).Returns(_user);

            _userLogic.Edit(1, _user);

            _userValidatorMock.VerifyAll();
            _userRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void IsValidToken()
        {
            _userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            var returnedValue = _userLogic.IsValidToken("1234-5678-90", null, null);

            _userRepositoryMock.VerifyAll();
            Assert.IsTrue(returnedValue);
        }

        [TestMethod]
        public void IsValidTokenWithId()
        {
            _userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            var returnedValue = _userLogic.IsValidToken("1234-5678-90", "1", null);

            _userRepositoryMock.VerifyAll();
            Assert.IsTrue(returnedValue);
        }

        [TestMethod]
        public void IsValidTokenWithUserIdParam()
        {
            _userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            var returnedValue = _userLogic.IsValidToken("1234-5678-90", null, "1");

            _userRepositoryMock.VerifyAll();
            Assert.IsTrue(returnedValue);
        }

        [TestMethod]
        public void IsValidTokenWithNonExistingUser()
        {
            _userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);

            var returnedValue = _userLogic.IsValidToken("1234-5678-90", null, null);

            _userRepositoryMock.VerifyAll();
            Assert.IsFalse(returnedValue);
        }

        [TestMethod]
        public void GetUserFromLogIn()
        {
            _userValidatorMock.Setup(m => m.ValidateEmailPassword("john.doe@test.com", "some_password"));
            _userRepositoryMock.Setup(m => m.Get(It.IsAny<Expression<Func<User, bool>>>(), null, null, false))
                .Returns(_user);

            var returnedUserFromLogin = _userLogic.GetUserFromLogIn("john.doe@test.com", "some_password");

            _userValidatorMock.VerifyAll();
            _userRepositoryMock.VerifyAll();
            Assert.AreEqual("John", returnedUserFromLogin.Name);
        }
    }
}