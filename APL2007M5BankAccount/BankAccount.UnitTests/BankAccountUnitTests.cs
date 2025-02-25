using BankAccountApp;
using System;
using Xunit;

namespace BankAccountUnitTests
{
    public class BankAccountTestsTest
    {
        [Fact]
        public void Credit_WithPositiveAmount_UpdatesBalance()
        {
            // Arrange
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);

            // Act
            account.Credit(50);

            // Assert
            Assert.Equal(150, account.GetBalance());
        }

        [Fact]
        public void Credit_WithNegativeAmount_ShouldThrowException()
        {
            // Arrange
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Credit(-50));
        }

        [Fact]
        public void Credit_WithZeroAmount_ShouldNotChangeBalance()
        {
            // Arrange
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);

            // Act
            account.Credit(0);

            // Assert
            Assert.Equal(100, account.GetBalance());
        }

        [Fact]
        public void Debit_WithSufficientBalance_ReducesBalance()
        {
            // Arrange
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);

            // Act
            account.Debit(50);

            // Assert
            Assert.Equal(50, account.GetBalance());
        }

        [Fact]
        public void Debit_WithInsufficientBalance_ThrowsException()
        {
            // Arrange
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);

            // Act & Assert
            Assert.Throws<Exception>(() => account.Debit(150));
        }

        [Fact]
        public void Debit_WithNegativeAmount_ShouldThrowException()
        {
            // Arrange
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Debit(-50));
        }

        [Fact]
        public void Debit_WithZeroAmount_ShouldNotChangeBalance()
        {
            // Arrange
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);

            // Act
            account.Debit(0);

            // Assert
            Assert.Equal(100, account.GetBalance());
        }

        [Fact]
        public void Transfer_WithSufficientBalance_ShouldDecreaseSourceAndIncreaseTargetBalance()
        {
            // Arrange
            var sourceAccount = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var targetAccount = new BankAccount("67890", 100, "Jane Doe", "Savings", DateTime.Now);

            // Act
            sourceAccount.Transfer(targetAccount, 50);

            // Assert
            Assert.Equal(50, sourceAccount.GetBalance());
            Assert.Equal(150, targetAccount.GetBalance());
        }

        [Fact]
        public void Transfer_WithInsufficientBalance_ShouldThrowException()
        {
            // Arrange
            var sourceAccount = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var targetAccount = new BankAccount("67890", 100, "Jane Doe", "Savings", DateTime.Now);

            // Act & Assert
            Assert.Throws<Exception>(() => sourceAccount.Transfer(targetAccount, 150));
        }

        [Fact]
        public void Transfer_WithNegativeAmount_ShouldThrowException()
        {
            // Arrange
            var sourceAccount = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var targetAccount = new BankAccount("67890", 100, "Jane Doe", "Savings", DateTime.Now);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => sourceAccount.Transfer(targetAccount, -50));
        }

        [Fact]
        public void Transfer_WithZeroAmount_ShouldNotChangeBalances()
        {
            // Arrange
            var sourceAccount = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var targetAccount = new BankAccount("67890", 100, "Jane Doe", "Savings", DateTime.Now);

            // Act
            sourceAccount.Transfer(targetAccount, 0);

            // Assert
            Assert.Equal(100, sourceAccount.GetBalance());
            Assert.Equal(100, targetAccount.GetBalance());
        }

        [Fact]
        public void Transfer_ToSameAccount_ShouldThrowException()
        {
            // Arrange
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Transfer(account, 50));
        }

        [Fact]
        public void Transfer_ToNullAccount_ShouldThrowException()
        {
            // Arrange
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => account.Transfer(null, 50));
        }

        [Fact]
        public void CalculateInterest_ShouldReturnCorrectAmount()
        {
            // Arrange
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);

            // Act
            var interest = account.CalculateInterest(0.05);

            // Assert
            Assert.Equal(5, interest);
        }

        [Fact]
        public void CalculateInterest_WithNegativeRate_ShouldThrowException()
        {
            // Arrange
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.CalculateInterest(-0.05));
        }

        [Fact]
        public void CalculateInterest_WithZeroRate_ShouldReturnZero()
        {
            // Arrange
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);

            // Act
            var interest = account.CalculateInterest(0);

            // Assert
            Assert.Equal(0, interest);
        }
    }
}