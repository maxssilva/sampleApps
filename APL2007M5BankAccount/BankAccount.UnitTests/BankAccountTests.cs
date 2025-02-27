using BankAccountApp;
using System;
using Xunit;

namespace BankAccountUnitTests
{
    public class BankAccountTests
    {
        [Fact]
        public void Credit_WithPositiveAmount_UpdatesBalance()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            account.Credit(50);
            Assert.Equal(150, account.Balance);
        }

        [Fact]
        public void Credit_WithNegativeAmount_ShouldThrowException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => account.Credit(-50));
        }

        [Fact]
        public void Debit_WithSufficientBalance_ReducesBalance()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            account.Debit(50);
            Assert.Equal(50, account.Balance);
        }

        [Fact]
        public void Debit_WithInsufficientBalance_ThrowsException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<InvalidOperationException>(() => account.Debit(150));
        }

        [Fact]
        public void Transfer_WithSufficientBalance_ShouldDecreaseSourceAndIncreaseTargetBalance()
        {
            var sourceAccount = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var targetAccount = new BankAccount("67890", 100, "Jane Doe", "Savings", DateTime.Now);
            sourceAccount.Transfer(targetAccount, 50);
            Assert.Equal(50, sourceAccount.Balance);
            Assert.Equal(150, targetAccount.Balance);
        }

        [Fact]
        public void Transfer_WithInsufficientBalance_ShouldThrowException()
        {
            var sourceAccount = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var targetAccount = new BankAccount("67890", 100, "Jane Doe", "Savings", DateTime.Now);
            Assert.Throws<InvalidOperationException>(() => sourceAccount.Transfer(targetAccount, 150));
        }

        [Fact]
        public void CalculateInterest_WithPositiveRate_ShouldReturnCorrectAmount()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var interest = account.CalculateInterest(0.05);
            Assert.Equal(5, interest);
        }

        [Fact]
        public void CalculateInterest_WithNegativeRate_ShouldThrowException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => account.CalculateInterest(-0.05));
        }
    }
}