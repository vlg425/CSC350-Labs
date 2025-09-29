using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class BankAccount
    {
        private string accountName;
        private int accountID;
        private decimal balance;
        // Each transaction stores: Type, Amount, BalanceAfter
        private List<(string Type, decimal Amount, decimal BalanceAfter)> transactions;

        public BankAccount(string name, decimal initialBalance, int ID = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Error: Account name cannot be empty.");
                accountName = "Unknown";
            }
            else
            {
                accountName = name;
            }

            if (initialBalance < 0)
            {
                Console.WriteLine("Error: Initial balance cannot be negative. Setting balance to 0.");
                balance = 0;
            }
            else
            {
                balance = initialBalance;
            }

            accountID = ID;
            transactions = new List<(string, decimal, decimal)>(); // starts empty
        }

        public string AccountName { get { return accountName; } }
        public int AccountID { get { return accountID; } }
        public decimal Balance { get { return balance; } }

        // Expose the tuple list so tests can check details
        public List<(string Type, decimal Amount, decimal BalanceAfter)> Transactions 
        { 
            get { return transactions; } 
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Error: Deposit must be greater than 0.");
                return;
            }

            balance += amount;
            transactions.Add(("Deposit", amount, balance));
            Console.WriteLine($"Deposited {amount:C}, New Balance: {balance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Error: Withdrawal must be greater than 0.");
                return;
            }
            else if (amount > balance)
            {
                Console.WriteLine("Error: Insufficient funds.");
                return;
            }

            balance -= amount;
            transactions.Add(("Withdrawal", amount, balance));
            Console.WriteLine($"Withdrew {amount:C}, New Balance: {balance:C}");
        }
    }
}
