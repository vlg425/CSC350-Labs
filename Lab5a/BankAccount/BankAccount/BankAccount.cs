
namespace BankAccount
{
    public class BankAccount
    {
        private string accountName;
        private int accountID;
        private decimal balance;
        private List<decimal> transactions;

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
            transactions = new List<decimal>();
        }

        public string AccountName { get { return accountName; } }
        public int AccountID { get { return accountID; } }
        public decimal Balance { get { return balance; } }
        public List<decimal> Transactions { get { return transactions; } }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Error: Deposit must be greater than 0.");
            }
            else
            {
                balance += amount;
                transactions.Add(amount);
                Console.WriteLine($"Deposited {amount:C}, New Balance: {balance:C}");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Error: Withdrawal must be greater than 0.");
            }
            else if (amount > balance)
            {
                Console.WriteLine("Error: Insufficient funds.");
            }
            else
            {
                balance -= amount;
                transactions.Add(-amount);
                Console.WriteLine($"Withdrew {amount:C}, New Balance: {balance:C}");
            }
        }
    }
}