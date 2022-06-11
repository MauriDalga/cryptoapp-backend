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
    public class TransactionValidatorTest
    {
        CoinAccount coinAccount = new();
        Transaction transaction = new();

        [TestInitialize]
        public void TestSetup()
        {
            coinAccount = new()
            {
                Id = 1,
                Balance = 10,
                UserId = 1,
                CoinId = 1
            };

            transaction = new()
            {
                Id = 1,
                Amount = 1,
                SenderId = 1,
                ReceiverId = 2,
                CoinId = 1
            };
        }

        [TestMethod]
        public void CreationValidation()
        {
            var transactionRepositoryMock = new Mock<IRepository<Transaction>>(MockBehavior.Strict);
            var transactionUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Transaction>()).Returns(transactionRepositoryMock.Object);

            var coinRepositoryMock = new Mock<IRepository<Coin>>(MockBehavior.Strict);
            coinRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<Coin, bool>>>())).Returns(true);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Coin>()).Returns(coinRepositoryMock.Object);

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            var coinAccountRepositoryMock = new Mock<IRepository<CoinAccount>>(MockBehavior.Strict);
            coinAccountRepositoryMock
                .Setup(m => m.Get(It.IsAny<Expression<Func<CoinAccount, bool>>>(), null, null, false)).Returns(coinAccount);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<CoinAccount>()).Returns(coinAccountRepositoryMock.Object);

            TransactionValidator transactionValidator = new(transactionUnitOfWorkMock.Object);
            transactionValidator.CreationValidation(transaction);
        }

        [TestMethod]
        public void CreationValidationZeroAmount()
        {
            Transaction transaction = new()
            {
                Id = 1,
                Amount = 0,
                SenderId = 1,
                ReceiverId = 2,
                CoinId = 1
            };

            var transactionRepositoryMock = new Mock<IRepository<Transaction>>(MockBehavior.Strict);
            var transactionUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Transaction>()).Returns(transactionRepositoryMock.Object);

            var coinRepositoryMock = new Mock<IRepository<Coin>>(MockBehavior.Strict);
            coinRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<Coin, bool>>>())).Returns(true);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Coin>()).Returns(coinRepositoryMock.Object);

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            var coinAccountRepositoryMock = new Mock<IRepository<CoinAccount>>(MockBehavior.Strict);
            coinAccountRepositoryMock
                .Setup(m => m.Get(It.IsAny<Expression<Func<CoinAccount, bool>>>(), null, null, false)).Returns(coinAccount);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<CoinAccount>()).Returns(coinAccountRepositoryMock.Object);

            TransactionValidator transactionValidator = new(transactionUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                transactionValidator.CreationValidation(transaction);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'amount' must be greater than 0.", errorMessage);
        }

        [TestMethod]
        public void CreationValidationZeroSenderId()
        {
            Transaction transaction = new()
            {
                Id = 1,
                Amount = 1,
                SenderId = 0,
                ReceiverId = 2,
                CoinId = 1
            };

            var transactionRepositoryMock = new Mock<IRepository<Transaction>>(MockBehavior.Strict);
            var transactionUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Transaction>()).Returns(transactionRepositoryMock.Object);

            var coinRepositoryMock = new Mock<IRepository<Coin>>(MockBehavior.Strict);
            coinRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<Coin, bool>>>())).Returns(true);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Coin>()).Returns(coinRepositoryMock.Object);

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            var coinAccountRepositoryMock = new Mock<IRepository<CoinAccount>>(MockBehavior.Strict);
            coinAccountRepositoryMock
                .Setup(m => m.Get(It.IsAny<Expression<Func<CoinAccount, bool>>>(), null, null, false)).Returns(coinAccount);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<CoinAccount>()).Returns(coinAccountRepositoryMock.Object);

            TransactionValidator transactionValidator = new(transactionUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                transactionValidator.CreationValidation(transaction);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'sender ID' must be greater than 0.", errorMessage);
        }

        [TestMethod]
        public void CreationValidationZeroReceiverId()
        {
            Transaction transaction = new()
            {
                Id = 1,
                Amount = 1,
                SenderId = 1,
                ReceiverId = 0,
                CoinId = 1
            };

            var transactionRepositoryMock = new Mock<IRepository<Transaction>>(MockBehavior.Strict);
            var transactionUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Transaction>()).Returns(transactionRepositoryMock.Object);

            var coinRepositoryMock = new Mock<IRepository<Coin>>(MockBehavior.Strict);
            coinRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<Coin, bool>>>())).Returns(true);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Coin>()).Returns(coinRepositoryMock.Object);

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            var coinAccountRepositoryMock = new Mock<IRepository<CoinAccount>>(MockBehavior.Strict);
            coinAccountRepositoryMock
                .Setup(m => m.Get(It.IsAny<Expression<Func<CoinAccount, bool>>>(), null, null, false)).Returns(coinAccount);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<CoinAccount>()).Returns(coinAccountRepositoryMock.Object);

            TransactionValidator transactionValidator = new(transactionUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                transactionValidator.CreationValidation(transaction);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'receiver ID' must be greater than 0.", errorMessage);
        }

        [TestMethod]
        public void CreationValidationZeroCoinId()
        {
            Transaction transaction = new()
            {
                Id = 1,
                Amount = 1,
                SenderId = 1,
                ReceiverId = 2,
                CoinId = 0
            };

            var transactionRepositoryMock = new Mock<IRepository<Transaction>>(MockBehavior.Strict);
            var transactionUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Transaction>()).Returns(transactionRepositoryMock.Object);

            var coinRepositoryMock = new Mock<IRepository<Coin>>(MockBehavior.Strict);
            coinRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<Coin, bool>>>())).Returns(true);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Coin>()).Returns(coinRepositoryMock.Object);

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            var coinAccountRepositoryMock = new Mock<IRepository<CoinAccount>>(MockBehavior.Strict);
            coinAccountRepositoryMock
                .Setup(m => m.Get(It.IsAny<Expression<Func<CoinAccount, bool>>>(), null, null, false)).Returns(coinAccount);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<CoinAccount>()).Returns(coinAccountRepositoryMock.Object);

            TransactionValidator transactionValidator = new(transactionUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                transactionValidator.CreationValidation(transaction);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Property 'coin ID' must be greater than 0.", errorMessage);
        }

        [TestMethod]
        public void CreationValidationSameSenderAndReceiver()
        {
            Transaction transaction = new()
            {
                Id = 1,
                Amount = 1,
                SenderId = 1,
                ReceiverId = 1,
                CoinId = 1
            };

            var transactionRepositoryMock = new Mock<IRepository<Transaction>>(MockBehavior.Strict);
            var transactionUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Transaction>()).Returns(transactionRepositoryMock.Object);

            var coinRepositoryMock = new Mock<IRepository<Coin>>(MockBehavior.Strict);
            coinRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<Coin, bool>>>())).Returns(true);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Coin>()).Returns(coinRepositoryMock.Object);

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            var coinAccountRepositoryMock = new Mock<IRepository<CoinAccount>>(MockBehavior.Strict);
            coinAccountRepositoryMock
                .Setup(m => m.Get(It.IsAny<Expression<Func<CoinAccount, bool>>>(), null, null, false)).Returns(coinAccount);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<CoinAccount>()).Returns(coinAccountRepositoryMock.Object);

            TransactionValidator transactionValidator = new(transactionUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                transactionValidator.CreationValidation(transaction);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Transaction failed. Please try again.", errorMessage);
        }

        [TestMethod]
        public void CreationValidationSenderOrReceiverNonExisting()
        {
            Transaction transaction = new()
            {
                Id = 1,
                Amount = 1,
                SenderId = 100,
                ReceiverId = 1,
                CoinId = 1
            };

            var transactionRepositoryMock = new Mock<IRepository<Transaction>>(MockBehavior.Strict);
            var transactionUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Transaction>()).Returns(transactionRepositoryMock.Object);

            var coinRepositoryMock = new Mock<IRepository<Coin>>(MockBehavior.Strict);
            coinRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<Coin, bool>>>())).Returns(true);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Coin>()).Returns(coinRepositoryMock.Object);

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            var coinAccountRepositoryMock = new Mock<IRepository<CoinAccount>>(MockBehavior.Strict);
            coinAccountRepositoryMock
                .Setup(m => m.Get(It.IsAny<Expression<Func<CoinAccount, bool>>>(), null, null, false)).Returns(coinAccount);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<CoinAccount>()).Returns(coinAccountRepositoryMock.Object);

            TransactionValidator transactionValidator = new(transactionUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                transactionValidator.CreationValidation(transaction);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Transaction failed. Please try again.", errorMessage);
        }

        [TestMethod]
        public void CreationValidationCoinNonExisting()
        {
            Transaction transaction = new()
            {
                Id = 1,
                Amount = 1,
                SenderId = 1,
                ReceiverId = 1,
                CoinId = 100
            };

            var transactionRepositoryMock = new Mock<IRepository<Transaction>>(MockBehavior.Strict);
            var transactionUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Transaction>()).Returns(transactionRepositoryMock.Object);

            var coinRepositoryMock = new Mock<IRepository<Coin>>(MockBehavior.Strict);
            coinRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<Coin, bool>>>())).Returns(false);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Coin>()).Returns(coinRepositoryMock.Object);

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);

            var coinAccountRepositoryMock = new Mock<IRepository<CoinAccount>>(MockBehavior.Strict);
            coinAccountRepositoryMock
                .Setup(m => m.Get(It.IsAny<Expression<Func<CoinAccount, bool>>>(), null, null, false)).Returns(coinAccount);

            transactionUnitOfWorkMock.Setup(m => m.GetRepository<CoinAccount>()).Returns(coinAccountRepositoryMock.Object);

            TransactionValidator transactionValidator = new(transactionUnitOfWorkMock.Object);

            string errorMessage = "";
            try
            {
                transactionValidator.CreationValidation(transaction);
            }
            catch (ArgumentException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.AreEqual("Transaction failed. Please try again.", errorMessage);
        }

        [TestMethod]
        public void CheckFunds()
        {
            Transaction transaction = new()
            {
                Id = 1,
                Amount = 1,
                SenderId = 1,
                ReceiverId = 1,
                CoinId = 100
            };

            var transactionRepositoryMock = new Mock<IRepository<Transaction>>(MockBehavior.Strict);

            var coinRepositoryMock = new Mock<IRepository<Coin>>(MockBehavior.Strict);
            coinRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<Coin, bool>>>())).Returns(true);

            var coinAccountRepositoryMock = new Mock<IRepository<CoinAccount>>(MockBehavior.Strict);
            coinAccountRepositoryMock
                .Setup(m => m.Get(It.IsAny<Expression<Func<CoinAccount, bool>>>(), null, null, false)).Returns(coinAccount);

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);


            var transactionUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Transaction>()).Returns(transactionRepositoryMock.Object);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Coin>()).Returns(coinRepositoryMock.Object);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<CoinAccount>()).Returns(coinAccountRepositoryMock.Object);

            TransactionValidator transactionValidator = new(transactionUnitOfWorkMock.Object);

            Assert.IsTrue(transactionValidator.CheckFunds(transaction));
        }

        [TestMethod]
        public void CheckFundsInsufficient()
        {
            Transaction transaction = new()
            {
                Id = 1,
                Amount = 1,
                SenderId = 1,
                ReceiverId = 1,
                CoinId = 100
            };

            CoinAccount coinAccount = new()
            {
                Id = 1,
                Balance = 0.5m,
                UserId = 1,
                CoinId = 1
            };

            var transactionRepositoryMock = new Mock<IRepository<Transaction>>(MockBehavior.Strict);

            var coinRepositoryMock = new Mock<IRepository<Coin>>(MockBehavior.Strict);
            coinRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<Coin, bool>>>())).Returns(true);

            var coinAccountRepositoryMock = new Mock<IRepository<CoinAccount>>(MockBehavior.Strict);
            coinAccountRepositoryMock
                .Setup(m => m.Get(It.IsAny<Expression<Func<CoinAccount, bool>>>(), null, null, false)).Returns(coinAccount);

            var userRepositoryMock = new Mock<IRepository<User>>(MockBehavior.Strict);
            userRepositoryMock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);


            var transactionUnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<User>()).Returns(userRepositoryMock.Object);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Transaction>()).Returns(transactionRepositoryMock.Object);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<Coin>()).Returns(coinRepositoryMock.Object);
            transactionUnitOfWorkMock.Setup(m => m.GetRepository<CoinAccount>()).Returns(coinAccountRepositoryMock.Object);

            TransactionValidator transactionValidator = new(transactionUnitOfWorkMock.Object);

            Assert.IsFalse(transactionValidator.CheckFunds(transaction));
        }
    }
}

