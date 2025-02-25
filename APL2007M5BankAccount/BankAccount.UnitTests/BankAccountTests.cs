using BankAccountApp;
using System;

namespace BankAccountUnitTests
{
    private readonly BankAccount _account;
    public BankAccountTests()
    {
        _account = new BankAccount("123456", 1000.0, "Igr Bltra", "Savings", DateTime.Now);
    }
    public class BankAccountTests
    {
        // Credit tests
        [Fact]
        public void Credit_WithPositiveAmount_UpdatesBalance()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            account.Credit(50);
            Assert.Equal(150, account.GetBalance());
        }

        [Fact]
        public void Credit_WithNegativeAmount_ShouldThrowException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => account.Credit(-50));
        }

        [Fact]
        public void Credit_WithZeroAmount_ShouldNotChangeBalance()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            account.Credit(0);
            Assert.Equal(100, account.GetBalance());
        }

        [Fact]
        public void Credit_WithMaxDoubleValue_ShouldUpdateBalance()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            account.Credit(double.MaxValue);
            Assert.Equal(double.MaxValue + 100, account.GetBalance());
        }

        [Fact]
        public void Credit_WithMinDoubleValue_ShouldThrowException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => account.Credit(double.MinValue));
        }

        [Fact]
        public void Credit_WithNaN_ShouldThrowException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => account.Credit(double.NaN));
        }

        [Fact]
        public void Credit_WithPositiveInfinity_ShouldThrowException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => account.Credit(double.PositiveInfinity));
        }

        [Fact]
        public void Credit_WithNegativeInfinity_ShouldThrowException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => account.Credit(double.NegativeInfinity));
        }

        // Debit tests
        [Fact]
        public void Debit_WithSufficientBalance_ReducesBalance()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            account.Debit(50);
            Assert.Equal(50, account.GetBalance());
        }

        [Fact]
        public void Debit_WithInsufficientBalance_ThrowsException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<Exception>(() => account.Debit(150));
        }

        [Fact]
        public void Debit_WithNegativeAmount_ShouldThrowException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => account.Debit(-50));
        }

        [Fact]
        public void Debit_WithZeroAmount_ShouldNotChangeBalance()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            account.Debit(0);
            Assert.Equal(100, account.GetBalance());
        }

        [Fact]
        public void Debit_WithMaxDoubleValue_ShouldThrowException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<Exception>(() => account.Debit(double.MaxValue));
        }

        [Fact]
        public void Debit_WithMinDoubleValue_ShouldThrowException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => account.Debit(double.MinValue));
        }

        [Fact]
        public void Debit_WithNaN_ShouldThrowException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => account.Debit(double.NaN));
        }

        [Fact]
        public void Debit_WithPositiveInfinity_ShouldThrowException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => account.Debit(double.PositiveInfinity));
        }

        [Fact]
        public void Debit_WithNegativeInfinity_ShouldThrowException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => account.Debit(double.NegativeInfinity));
        }

        // Transfer tests
        [Fact]
        public void Transfer_WithSufficientBalance_ShouldDecreaseSourceAndIncreaseTargetBalance()
        {
            var sourceAccount = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var targetAccount = new BankAccount("67890", 100, "Jane Doe", "Savings", DateTime.Now);
            sourceAccount.Transfer(targetAccount, 50);
            Assert.Equal(50, sourceAccount.GetBalance());
            Assert.Equal(150, targetAccount.GetBalance());
        }

        [Fact]
        public void Transfer_WithInsufficientBalance_ShouldThrowException()
        {
            var sourceAccount = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var targetAccount = new BankAccount("67890", 100, "Jane Doe", "Savings", DateTime.Now);
            Assert.Throws<Exception>(() => sourceAccount.Transfer(targetAccount, 150));
        }

        [Fact]
        public void Transfer_WithNegativeAmount_ShouldThrowException()
        {
            var sourceAccount = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var targetAccount = new BankAccount("67890", 100, "Jane Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => sourceAccount.Transfer(targetAccount, -50));
        }

        [Fact]
        public void Transfer_WithZeroAmount_ShouldNotChangeBalances()
        {
            var sourceAccount = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var targetAccount = new BankAccount("67890", 100, "Jane Doe", "Savings", DateTime.Now);
            sourceAccount.Transfer(targetAccount, 0);
            Assert.Equal(100, sourceAccount.GetBalance());
            Assert.Equal(100, targetAccount.GetBalance());
        }

        [Fact]
        public void Transfer_ToSameAccount_ShouldThrowException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => account.Transfer(account, 50));
        }

        [Fact]
        public void Transfer_ToNullAccount_ShouldThrowException()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentNullException>(() => account.Transfer(null, 50));
        }

        [Fact]
        public void Transfer_WithMaxDoubleValue_ShouldThrowException()
        {
            var sourceAccount = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var targetAccount = new BankAccount("67890", 100, "Jane Doe", "Savings", DateTime.Now);
            Assert.Throws<Exception>(() => sourceAccount.Transfer(targetAccount, double.MaxValue));
        }

        [Fact]
        public void Transfer_WithMinDoubleValue_ShouldThrowException()
        {
            var sourceAccount = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var targetAccount = new BankAccount("67890", 100, "Jane Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => sourceAccount.Transfer(targetAccount, double.MinValue));
        }

        [Fact]
        public void Transfer_WithNaN_ShouldThrowException()
        {
            var sourceAccount = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var targetAccount = new BankAccount("67890", 100, "Jane Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => sourceAccount.Transfer(targetAccount, double.NaN));
        }

        [Fact]
        public void Transfer_WithPositiveInfinity_ShouldThrowException()
        {
            var sourceAccount = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var targetAccount = new BankAccount("67890", 100, "Jane Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => sourceAccount.Transfer(targetAccount, double.PositiveInfinity));
        }

        [Fact]
        public void Transfer_WithNegativeInfinity_ShouldThrowException()
        {
            var sourceAccount = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var targetAccount = new BankAccount("67890", 100, "Jane Doe", "Savings", DateTime.Now);
            Assert.Throws<ArgumentException>(() => sourceAccount.Transfer(targetAccount, double.NegativeInfinity));
        }

        // CalculateInterest tests
        [Fact]
        public void CalculateInterest_ShouldReturnCorrectAmount()
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

        [Fact]
        public void CalculateInterest_WithZeroRate_ShouldReturnZero()
        {
            var account = new BankAccount("12345", 100, "John Doe", "Savings", DateTime.Now);
            var interest = account.CalculateInterest(0);
            Assert.Equal(0, interest);
        }
    }
}
