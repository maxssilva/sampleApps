using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccountApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();

            // Create bank accounts with random balances
            int numberOfAccounts = 20;
            int createdAccounts = 0;
            while (createdAccounts < numberOfAccounts)
            {
                try
                {
                    double initialBalance = GenerateRandomBalance(10, 50000);
                    string accountHolderName = GenerateRandomAccountHolder();
                    string accountType = GenerateRandomAccountType();
                    DateTime dateOpened = GenerateRandomDateOpened();
                    BankAccount account = new BankAccount($"Account {createdAccounts + 1}", initialBalance, accountHolderName, accountType, dateOpened);
                    accounts.Add(account);
                    createdAccounts++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Account creation failed: {ex.Message}");
                }
            }

            // Simulate 100 transactions for each account
            List<Task> transactionTasks = new List<Task>();
            foreach (BankAccount account in accounts)
            {
                transactionTasks.Add(Task.Run(() => SimulateTransactions(account, 100)));
            }

            await Task.WhenAll(transactionTasks);

            // Display account details
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine($"Account Number: {account.AccountNumber}, Balance: {account.Balance:C}, Holder: {account.AccountHolderName}, Type: {account.AccountType}, Opened: {account.DateOpened.ToShortDateString()}");
            }
        }

        static double GenerateRandomBalance(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }

        static string GenerateRandomAccountHolder()
        {
            string[] names = { "John Doe", "Jane Smith", "Alice Johnson", "Bob Brown", "Charlie Davis" };
            Random random = new Random();
            return names[random.Next(names.Length)];
        }

        static string GenerateRandomAccountType()
        {
            string[] types = { "Savings", "Checking", "Business" };
            Random random = new Random();
            return types[random.Next(types.Length)];
        }

        static DateTime GenerateRandomDateOpened()
        {
            Random random = new Random();
            int year = random.Next(2000, DateTime.Now.Year + 1);
            int month = random.Next(1, 13);
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            return new DateTime(year, month, day);
        }

        static void SimulateTransactions(BankAccount account, int numberOfTransactions)
        {
            Random random = new Random();
            for (int i = 0; i < numberOfTransactions; i++)
            {
                try
                {
                    double amount = random.NextDouble() * 1000;
                    if (random.Next(2) == 0)
                    {
                        account.Credit(amount);
                    }
                    else
                    {
                        account.Debit(amount);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Transaction failed for account {account.AccountNumber}: {ex.Message}");
                }
            }
        }
    }
}