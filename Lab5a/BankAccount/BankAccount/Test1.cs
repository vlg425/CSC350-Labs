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
        //positive deposit increases balance correctly
        Assert.AreEqual(account.Balance, expected, "Deposit not calculated correctly");
        //records transaction in list
        //invalid deposit amount such as negative and zero



    }

    [TestMethod]
    public void WithdrawTest()
    {
        // WITHDRAW


    }

    [TestMethod]
    public void TransactionRecordTest()
    {
        // TRANSACTION HISTORY
        
    }

    [TestMethod]
    public void AccountBalanceTest()
    {

    }
    
}
