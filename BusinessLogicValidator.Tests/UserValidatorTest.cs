using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessLogicValidator.Entities;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicValidator.Tests
{
    [TestClass]
    public class UserValidatorTest
    {
        User user = new();

        [TestInitialize]
        public void TestSetup()
        {
            user = new User()
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe",
                Email = "john.doe@test.com",
                Password = "testPassword",
                Image = ""
            };
        }

        [TestMethod]
        public void CreationValidation()
        {
            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);
            userValidator.CreationValidation(user);
        }

        [TestMethod]
        public void CreationValidationEmptyName()
        {
            User user = new()
            {
                Id = 1,
                Name = "",
                Lastname = "Doe",
                Email = "john.doe@test.com",
                Password = "testPassword"
            };

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.CreationValidation(user);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'name' can't be empty.", errorMessage);
        }

        [TestMethod]
        public void CreationValidationEmptyLastname()
        {
            User user = new()
            {
                Id = 1,
                Name = "John",
                Lastname = "",
                Email = "john.doe@test.com",
                Password = "testPassword"
            };

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.CreationValidation(user);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'lastname' can't be empty.", errorMessage);
        }

        [TestMethod]
        public void CreationValidationEmptyEmail()
        {
            User user = new()
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe",
                Email = "",
                Password = "testPassword"
            };

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.CreationValidation(user);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'email' has incorrect format.", errorMessage);
        }

        [TestMethod]
        public void CreationValidationEmptyPassword()
        {
            User user = new()
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe",
                Email = "john.doe@test.com",
                Password = ""
            };

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.CreationValidation(user);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'password' should have 7 characters or more.", errorMessage);
        }

        [TestMethod]
        public void CreationValidationPasswordWithBadFormat()
        {
            User user = new()
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe",
                Email = "john.doe@test.com",
                Password = "passw"
            };

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.CreationValidation(user);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'password' should have 7 characters or more.", errorMessage);
        }

        [TestMethod]
        public void CreationValidationIncorrectEmailFormat()
        {
            User user = new()
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe",
                Email = "john.doetest.com",
                Password = "testPassword"
            };

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.CreationValidation(user);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'email' has incorrect format.", errorMessage);
        }

        [TestMethod]
        public void CreationValidationExistingEmail()
        {
            User user = new()
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe",
                Email = "john.doe@test.com",
                Password = "testPassword"
            };

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.CreationValidation(user);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Email: john.doe@test.com is already in use.", errorMessage);
        }

        [TestMethod]
        public void ValidateIdentifier()
        {
            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);
            userValidator.ValidateIdentifier(1);
        }

        [TestMethod]
        public void ValidateIdentifierLessOrEqualThanZero()
        {
            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.ValidateIdentifier(0);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("ID can't be less or equal to 0.", errorMessage);
        }

        [TestMethod]
        public void ValidateIdentifierNonExisting()
        {
            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.ValidateIdentifier(1234);
            }
            catch (KeyNotFoundException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("ID: 1234 not found.", errorMessage);
        }

        [TestMethod]
        public void EditionValidation()
        {
            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Get(It.IsAny<Expression<Func<User, bool>>>(), null, null, false)).Returns(user);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);
            userValidator.EditionValidation(1, user);
        }

        [TestMethod]
        public void EditionValidationEmptyName()
        {
            User user = new()
            {
                Id = 1,
                Name = "",
                Lastname = "Doe",
                Email = "john.doe@test.com",
                Password = "testPassword"
            };

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.EditionValidation(1, user);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'name' can't be empty.", errorMessage);
        }

        [TestMethod]
        public void EditionValidationEmptyLastname()
        {
            User user = new()
            {
                Id = 1,
                Name = "John",
                Lastname = "",
                Email = "john.doe@test.com",
                Password = "testPassword"
            };

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.EditionValidation(1, user);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'lastname' can't be empty.", errorMessage);
        }

        [TestMethod]
        public void EditionValidationEmptyEmail()
        {
            User user = new()
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe",
                Email = "",
                Password = "testPassword"
            };

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.EditionValidation(1, user);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'email' has incorrect format.", errorMessage);
        }

        [TestMethod]
        public void EditionValidationEmptyPassword()
        {
            User user = new()
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe",
                Email = "john.doe@test.com",
                Password = ""
            };

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.EditionValidation(1, user);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'password' should have 7 characters or more.", errorMessage);
        }

        [TestMethod]
        public void EditionValidationPasswordWithBadFormat()
        {
            User user = new()
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe",
                Email = "john.doe@test.com",
                Password = "passw"
            };

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.EditionValidation(1, user);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'password' should have 7 characters or more.", errorMessage);
        }

        [TestMethod]
        public void EditionValidationIncorrectEmailFormat()
        {
            User user = new()
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe",
                Email = "john.doetest.com",
                Password = "testPassword"
            };

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.EditionValidation(1, user);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'email' has incorrect format.", errorMessage);
        }

        [TestMethod]
        public void EditionValidationChangingEmail()
        {
            User editUser = new()
            {
                Id = 1,
                Name = "John",
                Lastname = "Doe",
                Email = "john.doe1@test.com",
                Password = "testPassword"
            };

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Get(It.IsAny<Expression<Func<User, bool>>>(), null, null, false)).Returns(user);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.EditionValidation(1, editUser);
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Email must remain the same.", errorMessage);
        }

        [TestMethod]
        public void LogInValidation()
        {
            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);
            userValidator.LogInValidation(user);
        }

        [TestMethod]
        public void ValidateEmailPassword()
        {
            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);
            userValidator.ValidateEmailPassword("john.doe@test.com", "some_password");
        }

        [TestMethod]
        public void ValidateEmailPasswordWithWrongCredentials()
        {
            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);

            var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            UserValidator userValidator = new(userUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                userValidator.ValidateEmailPassword("john.doe@test.com", "some_password");
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Invalid credentials.", errorMessage);
        }
    }
}

