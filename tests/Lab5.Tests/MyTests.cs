using Domain.Abstractions;
using Domain.Exceptions;
using Domain.Models;
using Domain.Services;
using Moq;
using Xunit;

namespace Lab5.Tests;

public class MyTests
{
        private readonly Mock<IAccountRepository> _accountRepositoryMock;
        private readonly Mock<ITransactionRepository> _transactionRepositoryMock;
        private readonly AccountService _accountService;

        public MyTests()
        {
            _accountRepositoryMock = new Mock<IAccountRepository>();
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _accountService = new AccountService(_accountRepositoryMock.Object, _transactionRepositoryMock.Object);
        }

        [Fact]
        public void Withdraw_ValidAmount_ShouldUpdateBalanceAndAddTransaction()
        {
            int accountNumber = 12345;
            int pin = 1234;
            int initialBalance = 1000;
            int withdrawAmount = 500;

            var account = new Account(accountNumber, pin, initialBalance);

            _accountRepositoryMock.Setup(r => r.VerifyPin(accountNumber, pin))
                .Returns(true);
            _accountRepositoryMock.Setup(r => r.GetAccount(accountNumber))
                .Returns(account);

            _accountService.Withdraw(accountNumber, pin, withdrawAmount);

            Assert.Equal(500, account.Balance);

            _accountRepositoryMock.Verify(r => r.UpdateAccount(account), Times.Once);

            _transactionRepositoryMock.Verify(
                r => r.AddTransaction(
                    It.Is<Transaction>(t =>
                        t.Type == "Withdraw" &&
                        t.Amount == withdrawAmount &&
                        t.NewBalance == 500),
                    accountNumber),
                Times.Once);
        }

        [Fact]
        public void Withdraw_InsufficientBalance_ShouldThrowException()
        {
            int accountNumber = 12345;
            int pin = 1234;
            int initialBalance = 300;
            int withdrawAmount = 500;

            var account = new Account(accountNumber, pin, initialBalance);

            _accountRepositoryMock.Setup(r => r.VerifyPin(accountNumber, pin))
                .Returns(true);
            _accountRepositoryMock.Setup(r => r.GetAccount(accountNumber))
                .Returns(account);

            InsufficientFundsException exception = Assert.Throws<InsufficientFundsException>(() =>
                _accountService.Withdraw(accountNumber, pin, withdrawAmount));

            Assert.Equal("Insufficient funds", exception.Message);

            _accountRepositoryMock.Verify(r => r.UpdateAccount(It.IsAny<Account>()), Times.Never);
            _transactionRepositoryMock.Verify(r => r.AddTransaction(It.IsAny<Transaction>(), accountNumber), Times.Never);
        }

        [Fact]
        public void Replenish_ValidAmount_ShouldUpdateBalanceAndAddTransaction()
        {
            int accountNumber = 12345;
            int pin = 1234;
            int initialBalance = 1000;
            int depositAmount = 500;

            var account = new Account(accountNumber, pin, initialBalance);

            _accountRepositoryMock.Setup(r => r.VerifyPin(accountNumber, pin))
                .Returns(true);
            _accountRepositoryMock.Setup(r => r.GetAccount(accountNumber))
                .Returns(account);

            _accountService.Replenish(accountNumber, pin, depositAmount);

            Assert.Equal(1500, account.Balance);

            _accountRepositoryMock.Verify(r => r.UpdateAccount(account), Times.Once);

            _transactionRepositoryMock.Verify(
                r => r.AddTransaction(
                    It.Is<Transaction>(t =>
                        t.Type == "Replenish" &&
                        t.Amount == depositAmount &&
                        t.NewBalance == 1500),
                    accountNumber),
                Times.Once);
        }
}