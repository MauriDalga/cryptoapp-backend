using System.Linq.Expressions;
using BusinessLogicValidatorInterface;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class UserTest
    {
        User user = new();
        List<User> users = new();

        [TestInitialize]
        public void TestSetup()
        {
            user = new User()
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe",
                Email = "john.doe@test.com",
                Password = "testPassword"
            };

            users = new() { user };
        }

        [TestMethod]
        public void AddUser()
        {
            var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);
            userValidatorMock.Setup(m => m.CreationValidation(user));

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.InsertAndSave(user));

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
            var returnedUser = userLogic.Add(user);

            userValidatorMock.VerifyAll();
            userRepositoryMock.VerifyAll();
            userUnitOfWorkMock.VerifyAll();
            Assert.AreEqual("Martin", returnedUser.Name);
        }

        [TestMethod]
        public void GetUserById()
        {
            var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);
            userValidatorMock.Setup(m => m.ValidateIdentifier(user.Id));

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Get(It.IsAny<Expression<Func<User, bool>>>(), null, null, false)).Returns(user);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
            var returnedUser = userLogic.Get(user.Id);

            userValidatorMock.VerifyAll();
            userRepositoryMock.VerifyAll();
            userUnitOfWorkMock.VerifyAll();
            Assert.AreEqual("Martin", returnedUser.Name);
        }

        [TestMethod]
        public void DeleteUser()
        {
            var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);
            userValidatorMock.Setup(m => m.ValidateIdentifier(1));

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.DeleteByIdAndSave(1));

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
            userLogic.Delete(1);

            userValidatorMock.VerifyAll();
            userRepositoryMock.VerifyAll();
            userUnitOfWorkMock.VerifyAll();
        }

        [TestMethod]
        public void UpdateUser()
        {
            var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);
            userValidatorMock.Setup(m => m.ValidateIdentifier(1));
            userValidatorMock.Setup(m => m.EditionValidation(1, user));

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.UpdateAndSave(user));

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
            userLogic.Edit(1, user);

            userValidatorMock.VerifyAll();
            userRepositoryMock.VerifyAll();
            userUnitOfWorkMock.VerifyAll();
        }

        [TestMethod]
        public void GetAllUsers()
        {
            var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.GetCollection(null, null, null, null)).Returns(users);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
            IEnumerable<User> returnedUsers = userLogic.GetCollection();

            userValidatorMock.VerifyAll();
            userRepositoryMock.VerifyAll();
            userUnitOfWorkMock.VerifyAll();
            Assert.AreEqual("Martin", returnedUsers.First().Name);
        }
    }
}