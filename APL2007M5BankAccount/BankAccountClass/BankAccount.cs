public class BankAccount
{
    public string AccountNumber { get; }
    public double Balance { get; private set; }
    public string AccountHolderName { get; }
    public string AccountType { get; }
    public DateTime DateOpened { get; }

    public BankAccount(string accountNumber, double initialBalance, string accountHolderName, string accountType, DateTime dateOpened)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
        AccountHolderName = accountHolderName;
        AccountType = accountType;
        DateOpened = dateOpened;
    }

    public void Credit(double amount)
    {
        try
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount to credit must be positive.");
            }
            Balance += amount;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void Debit(double amount)
    {
        try
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount to debit must be positive.");
            }

            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new InvalidOperationException("Insufficient balance for debit.");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public double GetBalance()
    {
        return Balance; // Math.Round(balance, 2);
    }

    public void Transfer(BankAccount toAccount, double amount)
    {
        try
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount to transfer must be positive.");
            }

            if (Balance >= amount)
            {
                if (AccountHolderName != toAccount.AccountHolderName && amount > 500)
                {
                    throw new InvalidOperationException("Transfer amount exceeds maximum limit for different account owners.");
                }

                Debit(amount);
                toAccount.Credit(amount);
            }
            else
            {
                throw new InvalidOperationException("Insufficient balance for transfer.");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void PrintStatement()
    {
        Console.WriteLine($"Account Number: {AccountNumber}, Balance: {Balance}");
        // Add code here to print recent transactions
    }

    public double CalculateInterest(double interestRate)
    {
        try
        {
            if (interestRate < 0)
            {
                throw new ArgumentException("Interest rate must be non-negative.");
            }
            return Balance * interestRate;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return 0;
        }
    }
}