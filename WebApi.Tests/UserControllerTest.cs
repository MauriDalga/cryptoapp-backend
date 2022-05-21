using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using BusinessLogic;
using BusinessLogicAdapter;
using BusinessLogicValidatorInterface;
using DataAccessInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Read;
using Model.Write;
using Moq;
using WebApi.Controllers;

namespace WebApi.Tests;

[TestClass]
public class UserControllerTest
{
    [TestMethod]
    public void TestGetAllUsersOk()
    {
        User user1 = new()
        {
            Id = 1,
            Name = "John",
            Lastname = "Doe",
            Email = "john.doe@test.com",
            Password = "test_password"
        };

        User user2 = new()
        {
            Id = 2,
            Name = "Doe",
            Lastname = "John",
            Email = "john.doe@test.com",
            Password = "test_password"
        };

        List<User> returnedUsers = new() { user1, user2 };
        IEnumerable<UserBasicModel> users = returnedUsers.Select(m => new UserBasicModel(m));

        var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);
        var userModelValidatorMock = new Mock<IBusinessValidator<UserModel>>(MockBehavior.Strict);

        var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
        userRepositoryMock.Setup(m => m.GetCollection(null, null, null, null)).Returns(returnedUsers);

        var mapperMock = new Mock<IMapper>(MockBehavior.Strict);
        mapperMock.Setup(m => m.Map<IEnumerable<UserBasicModel>>(It.IsAny<object>())).Returns(users);

        var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
        userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

        UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
        UserLogicAdapter userLogicAdapter = new(userLogic, userModelValidatorMock.Object, mapperMock.Object);

        var controller = new UserController(userLogicAdapter);

        var result = controller.Get();
        var okResult = result as OkObjectResult;
        IEnumerable<UserBasicModel> getUsers = okResult.Value as IEnumerable<UserBasicModel>;

        userValidatorMock.VerifyAll();
        userModelValidatorMock.VerifyAll();
        userRepositoryMock.VerifyAll();
        mapperMock.VerifyAll();
        userUnitOfWorkMock.VerifyAll();

        Assert.IsTrue(users.SequenceEqual(getUsers));
    }

    [TestMethod]
    public void TestEmptyGetAllUsersOk()
    {
        List<User> returnedUsers = new();

        IEnumerable<UserBasicModel> users = returnedUsers.Select(m => new UserBasicModel(m));

        var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);
        var userModelValidatorMock = new Mock<IBusinessValidator<UserModel>>(MockBehavior.Strict);

        var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
        userRepositoryMock.Setup(m => m.GetCollection(null, null, null, null)).Returns(returnedUsers);

        var mapperMock = new Mock<IMapper>(MockBehavior.Strict);
        mapperMock.Setup(m => m.Map<IEnumerable<UserBasicModel>>(It.IsAny<object>())).Returns(users);

        var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
        userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

        UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
        UserLogicAdapter userLogicAdapter = new(userLogic, userModelValidatorMock.Object, mapperMock.Object);

        var controller = new UserController(userLogicAdapter);

        var result = controller.Get();
        var okResult = result as OkObjectResult;
        IEnumerable<UserBasicModel> getUsers = okResult.Value as IEnumerable<UserBasicModel>;

        userValidatorMock.VerifyAll();
        userModelValidatorMock.VerifyAll();
        userRepositoryMock.VerifyAll();
        mapperMock.VerifyAll();
        userUnitOfWorkMock.VerifyAll();

        Assert.IsTrue(users.SequenceEqual(getUsers));
    }

    [TestMethod]
    public void TestGetByIdUserOk()
    {
        int userId = 1;

        User returnedUser = new()
        {
            Id = 1,
            Name = "John",
            Lastname = "Doe",
            Email = "john.doe@test.com",
            Password = "Password_1",
        };

        var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);
        userValidatorMock.Setup(m => m.ValidateIdentifier(1));

        var userModelValidatorMock = new Mock<IBusinessValidator<UserModel>>(MockBehavior.Strict);
        userModelValidatorMock.Setup(m => m.ValidateIdentifier(1));

        var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
        userRepositoryMock.Setup(m => m.Get(It.IsAny<Expression<Func<User, bool>>>(), null, null, false)).Returns(returnedUser);

        var mapperMock = new Mock<IMapper>(MockBehavior.Strict);
        mapperMock.Setup(m => m.Map<UserDetailInfoModel>(It.IsAny<object>())).Returns(new UserDetailInfoModel(returnedUser));

        var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
        userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

        UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
        UserLogicAdapter userLogicAdapter = new(userLogic, userModelValidatorMock.Object, mapperMock.Object);

        var controller = new UserController(userLogicAdapter);

        var result = controller.Get(userId);
        var okResult = result as OkObjectResult;
        UserDetailInfoModel user = okResult.Value as UserDetailInfoModel;

        userValidatorMock.VerifyAll();
        userModelValidatorMock.VerifyAll();
        userRepositoryMock.VerifyAll();
        mapperMock.VerifyAll();
        userUnitOfWorkMock.VerifyAll();

        Assert.IsTrue(new UserDetailInfoModel(returnedUser).Equals(user));
    }

    [TestMethod]
    public void TestGetByIdUserNotFound()
    {
        var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);
        var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
        var mapperMock = new Mock<IMapper>(MockBehavior.Strict);

        var userModelValidatorMock = new Mock<IBusinessValidator<UserModel>>(MockBehavior.Strict);
        userModelValidatorMock.Setup(m => m.ValidateIdentifier(1)).Throws(new ArgumentException());

        var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
        userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

        UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
        UserLogicAdapter userLogicAdapter = new(userLogic, userModelValidatorMock.Object, mapperMock.Object);

        var controller = new UserController(userLogicAdapter);
        var result = controller.Get(1);
        
        userValidatorMock.VerifyAll();
        userModelValidatorMock.VerifyAll();
        userRepositoryMock.VerifyAll();
        mapperMock.VerifyAll();
        userUnitOfWorkMock.VerifyAll();

        Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
    }

    [TestMethod]
    public void TestPostUserOk()
    {
        UserModel userModel = new()
        {
            Name = "John",
            Lastname = "Doe",
            Email = "john.doe@test.com",
            Password = "Password_1",
        };

        User userToReturn = new()
        {
            Id = 1,
            Name = "John",
            Lastname = "Doe",
            Email = "john.doe@test.com",
            Password = "Password_1",
        };

        var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);
        userValidatorMock.Setup(m => m.CreationValidation(userToReturn));

        var userModelValidatorMock = new Mock<IBusinessValidator<UserModel>>(MockBehavior.Strict);
        userModelValidatorMock.Setup(m => m.CreationValidation(userModel));

        var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
        userRepositoryMock.Setup(m => m.InsertAndSave(userToReturn));

        var mapperMock = new Mock<IMapper>(MockBehavior.Strict);
        mapperMock.Setup(m => m.Map<User>(It.IsAny<object>())).Returns(userToReturn);
        mapperMock.Setup(m => m.Map<UserDetailInfoModel>(It.IsAny<object>())).Returns(new UserDetailInfoModel(userToReturn));

        var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
        userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

        UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
        UserLogicAdapter userLogicAdapter = new(userLogic, userModelValidatorMock.Object, mapperMock.Object);

        var controller = new UserController(userLogicAdapter);

        var result = controller.Post(userModel);
        var okResult = result as CreatedAtRouteResult;
        UserDetailInfoModel user = okResult.Value as UserDetailInfoModel;

        userValidatorMock.VerifyAll();
        userModelValidatorMock.VerifyAll();
        userRepositoryMock.VerifyAll();
        mapperMock.VerifyAll();
        userUnitOfWorkMock.VerifyAll();

        Assert.AreEqual(user, new UserDetailInfoModel(userToReturn));
    }

    [TestMethod]
    public void TestPostInvalidUser()
    {
        UserModel userModel = new()
        {
            Name = "",
            Email = "user_1@gmail.com",
            Password = "Password_1",
        };

        User user = new()
        {
            Name = "",
            Email = "user_1@gmail.com",
            Password = "Password_1",
        };

        var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);
        var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
        var mapperMock = new Mock<IMapper>(MockBehavior.Strict);

        var userModelValidatorMock = new Mock<IBusinessValidator<UserModel>>(MockBehavior.Strict);
        userModelValidatorMock.Setup(m => m.CreationValidation(userModel)).Throws(new ArgumentException());

        var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
        userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

        UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
        UserLogicAdapter userLogicAdapter = new(userLogic, userModelValidatorMock.Object, mapperMock.Object);

        var controller = new UserController(userLogicAdapter);
        var result = controller.Post(userModel);

        userValidatorMock.VerifyAll();
        userModelValidatorMock.VerifyAll();
        userRepositoryMock.VerifyAll();
        mapperMock.VerifyAll();
        userUnitOfWorkMock.VerifyAll();

        Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
    }

    [TestMethod]
    public void TestPutUserOk()
    {
        UserModel userModel = new()
        {
            Name = "John",
            Lastname = "Doe",
            Email = "john.doe@test.com",
            Password = "Password_1",
        };

        User userToReturn = new()
        {
            Id = 1,
            Name = "John",
            Lastname = "Dos",
            Email = "john.doe@test.com",
            Password = "Password_1",
        };

        var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);
        userValidatorMock.Setup(m => m.ValidateIdentifier(1));
        userValidatorMock.Setup(m => m.EditionValidation(1, userToReturn));

        var userModelValidatorMock = new Mock<IBusinessValidator<UserModel>>(MockBehavior.Strict);
        userModelValidatorMock.Setup(m => m.ValidateIdentifier(1));
        userModelValidatorMock.Setup(m => m.EditionValidation(1, userModel));

        var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
        userRepositoryMock.Setup(m => m.UpdateAndSave(userToReturn));

        var mapperMock = new Mock<IMapper>(MockBehavior.Strict);
        mapperMock.Setup(m => m.Map<User>(It.IsAny<object>())).Returns(userToReturn);

        var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
        userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

        UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
        UserLogicAdapter userLogicAdapter = new(userLogic, userModelValidatorMock.Object, mapperMock.Object);

        var controller = new UserController(userLogicAdapter);
        var result = controller.Put(1, userModel);

        userValidatorMock.VerifyAll();
        userModelValidatorMock.VerifyAll();
        userRepositoryMock.VerifyAll();
        mapperMock.VerifyAll();
        userUnitOfWorkMock.VerifyAll();

        Assert.IsInstanceOfType(result, typeof(NoContentResult));
    }

    [TestMethod]
    public void TestPutInvalidUser()
    {
        UserModel userModel = new()
        {
            Name = "",
            Email = "user_1@gmail.com",
            Password = "Password_1",
        };

        var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);

        var userModelValidatorMock = new Mock<IBusinessValidator<UserModel>>(MockBehavior.Strict);
        userModelValidatorMock.Setup(m => m.ValidateIdentifier(1));
        userModelValidatorMock.Setup(m => m.EditionValidation(1, userModel)).Throws(new ArgumentException());

        var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);

        var mapperMock = new Mock<IMapper>(MockBehavior.Strict);

        var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
        userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

        UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
        UserLogicAdapter userLogicAdapter = new(userLogic, userModelValidatorMock.Object, mapperMock.Object);

        var controller = new UserController(userLogicAdapter);
        var result = controller.Put(1, userModel);

        userValidatorMock.VerifyAll();
        userModelValidatorMock.VerifyAll();
        userRepositoryMock.VerifyAll();
        mapperMock.VerifyAll();
        userUnitOfWorkMock.VerifyAll();

        Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
    }

    [TestMethod]
    public void TestPutUserNotFound()
    {
        UserModel userModel = new()
        {
            Name = "John",
            Lastname = "Doe",
            Email = "john.doe@test.com",
            Password = "Password_1",
        };

        var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);

        var userModelValidatorMock = new Mock<IBusinessValidator<UserModel>>(MockBehavior.Strict);
        userModelValidatorMock.Setup(m => m.ValidateIdentifier(1111)).Throws(new ArgumentException());

        var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);

        var mapperMock = new Mock<IMapper>(MockBehavior.Strict);

        var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
        userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

        UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
        UserLogicAdapter userLogicAdapter = new(userLogic, userModelValidatorMock.Object, mapperMock.Object);

        var controller = new UserController(userLogicAdapter);
        var result = controller.Put(1111, userModel);

        userValidatorMock.VerifyAll();
        userModelValidatorMock.VerifyAll();
        userRepositoryMock.VerifyAll();
        mapperMock.VerifyAll();
        userUnitOfWorkMock.VerifyAll();

        Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
    }

    [TestMethod]
    public void TestDeleteUserOk()
    {
        var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);
        userValidatorMock.Setup(m => m.ValidateIdentifier(1));

        var userModelValidatorMock = new Mock<IBusinessValidator<UserModel>>(MockBehavior.Strict);
        userModelValidatorMock.Setup(m => m.ValidateIdentifier(1));

        var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
        userRepositoryMock.Setup(m => m.DeleteByIdAndSave(1));

        var mapperMock = new Mock<IMapper>(MockBehavior.Strict);

        var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
        userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

        UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
        UserLogicAdapter userLogicAdapter = new(userLogic, userModelValidatorMock.Object, mapperMock.Object);

        var controller = new UserController(userLogicAdapter);
        var result = controller.Delete(1);

        userValidatorMock.VerifyAll();
        userModelValidatorMock.VerifyAll();
        userRepositoryMock.VerifyAll();
        mapperMock.VerifyAll();
        userUnitOfWorkMock.VerifyAll();

        Assert.IsInstanceOfType(result, typeof(NoContentResult));
    }

    [TestMethod]
    public void TestDeleteUserNotFound()
    {
        var userValidatorMock = new Mock<IBusinessValidator<User>>(MockBehavior.Strict);
        userValidatorMock.Setup(m => m.ValidateIdentifier(1)).Throws(new ArgumentException());

        var userModelValidatorMock = new Mock<IBusinessValidator<UserModel>>(MockBehavior.Strict);
        userModelValidatorMock.Setup(m => m.ValidateIdentifier(1));

        var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
        var mapperMock = new Mock<IMapper>(MockBehavior.Strict);

        var userUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
        userUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

        UserLogic userLogic = new(userValidatorMock.Object, userUnitOfWorkMock.Object);
        UserLogicAdapter userLogicAdapter = new(userLogic, userModelValidatorMock.Object, mapperMock.Object);

        var controller = new UserController(userLogicAdapter);
        var result = controller.Delete(1);

        userValidatorMock.VerifyAll();
        userModelValidatorMock.VerifyAll();
        userRepositoryMock.VerifyAll();
        mapperMock.VerifyAll();
        userUnitOfWorkMock.VerifyAll();

        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }
}