namespace BankAccount;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        decimal beginningBalance = 11.99m;
        decimal debitAmount = 4.55m;
        decimal expected = 7.44m;

        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

        account.Withdraw(debitAmount);

        decimal actual = account.Balance;
        Assert.AreEqual(expected, actual, 0.0001m, "Account not debited correctly");
    }

    [TestMethod]
    public void ConstructorTest()
    {

        // Arrange
        decimal beginningBalance = 11.99m;
        int expected = 0;

        // Act
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

        // Assert
        Assert.IsNotNull(account.AccountName, "Account name not given");
        Assert.IsNotNull(account.Balance, "Balance not given");
        Assert.AreEqual(expected, account.Transactions.Count, "Transactions list not empty");

    }

    [TestMethod]
    public void DepositTest()
    {
        // DEPOSIT

        // Arrange
        decimal beginningBalance = 425.90m;
        decimal depositAmount = 12.25m;
        decimal expected = 425.90m + 12.25m;
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

        //Act
        account.Deposit(depositAmount);

        //Assert
        // positive deposit increases balance correctly
        Assert.AreEqual(expected, account.Balance, 0.0001m, "Deposit not calculated correctly");

        // records transaction in list
        Assert.AreEqual(1, account.Transactions.Count, "Deposit should create one transaction record");

        // verify transaction details reflect correctly
        var t = account.Transactions[0];
        Assert.AreEqual("Deposit", t.Type, "Transaction type should be Deposit");
        Assert.AreEqual(depositAmount, t.Amount, "Transaction amount incorrect");
        Assert.AreEqual(expected, t.BalanceAfter, 0.0001m, "BalanceAfter incorrect on deposit transaction");
    }


    [TestMethod]
    public void WithdrawTest()
    {
        // WITHDRAW

        // Arrange
        decimal beginningBalance = 100.00m;
        decimal withdrawAmount = 40.00m;
        decimal expected = 60.00m;
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

        // Act
        account.Withdraw(withdrawAmount);

        // Assert
        Assert.AreEqual(expected, account.Balance, 0.0001m, "Withdraw did not reduce balance correctly");
        Assert.AreEqual(1, account.Transactions.Count, "Withdraw should create one transaction record");

        // verify transaction details reflect correctly
        var t = account.Transactions[0];
        Assert.AreEqual("Withdrawal", t.Type, "Transaction type should be Withdrawal");
        Assert.AreEqual(withdrawAmount, t.Amount, "Transaction amount incorrect");
        Assert.AreEqual(expected, t.BalanceAfter, 0.0001m, "BalanceAfter incorrect on withdrawal transaction");
    }


    [TestMethod]
    public void TransactionRecordTest()
    {
        // TRANSACTION HISTORY

        // Arrange
        BankAccount account = new BankAccount("Mr. Bryan Walton", 50.00m);

        // Act
        account.Deposit(25.00m);   // Balance: 75.00
        account.Withdraw(10.00m);  // Balance: 65.00

        // Assert (count)
        Assert.AreEqual(2, account.Transactions.Count, "Should have two transaction records after one deposit and one withdrawal");

        // Assert details for first transaction (deposit)
        var first = account.Transactions[0];
        Assert.AreEqual("Deposit", first.Type, "First transaction should be a Deposit");
        Assert.AreEqual(25.00m, first.Amount, "Deposit amount incorrect");
        Assert.AreEqual(75.00m, first.BalanceAfter, 0.0001m, "Balance after deposit incorrect");

        // Assert details for second transaction (withdrawal)
        var second = account.Transactions[1];
        Assert.AreEqual("Withdrawal", second.Type, "Second transaction should be a Withdrawal");
        Assert.AreEqual(10.00m, second.Amount, "Withdrawal amount incorrect");
        Assert.AreEqual(65.00m, second.BalanceAfter, 0.0001m, "Balance after withdrawal incorrect");
    }



    [TestMethod]
    public void AccountBalanceTest()
    {
        // Arrange
        decimal beginningBalance = 50.00m;
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

        // Act
        account.Deposit(25.00m);  // Balance: 75.00
        account.Withdraw(10.00m); // Balance: 65.00
        account.Deposit(5.00m);   // Balance: 70.00

        // Assert final balance
        Assert.AreEqual(70.00m, account.Balance, 0.0001m, "Running balance not calculated correctly after multiple operations");

        // Assert transaction count
        Assert.AreEqual(3, account.Transactions.Count, "Should have three transaction records after three operations");

        // Transaction 1: Deposit 25
        var t1 = account.Transactions[0];
        Assert.AreEqual("Deposit", t1.Type, "First transaction should be a Deposit");
        Assert.AreEqual(25.00m, t1.Amount, "Deposit amount incorrect");
        Assert.AreEqual(75.00m, t1.BalanceAfter, 0.0001m, "Balance after first deposit incorrect");

        // Transaction 2: Withdraw 10
        var t2 = account.Transactions[1];
        Assert.AreEqual("Withdrawal", t2.Type, "Second transaction should be a Withdrawal");
        Assert.AreEqual(10.00m, t2.Amount, "Withdrawal amount incorrect");
        Assert.AreEqual(65.00m, t2.BalanceAfter, 0.0001m, "Balance after withdrawal incorrect");

        // Transaction 3: Deposit 5
        var t3 = account.Transactions[2];
        Assert.AreEqual("Deposit", t3.Type, "Third transaction should be a Deposit");
        Assert.AreEqual(5.00m, t3.Amount, "Deposit amount incorrect");
        Assert.AreEqual(70.00m, t3.BalanceAfter, 0.0001m, "Balance after second deposit incorrect");
    }

}
