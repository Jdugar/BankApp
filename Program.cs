using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = Bank.createAccount("testc@gmail.com", Typeofaccount.Checking,$245);
           
            var acct1 = new Account
            {
                EmailAddress = "acct1@gmail.com",
                Accounttype = Typeofaccount.Checking
            };
            acct.Deposit();
            acct1.Deposit();
            acct.Print();
            acct1.Print();
            acct.Deposit();
            acct.Print();
            //Console.WriteLine($"AccountType {acct.Accounttype}");
           /* Console.WriteLine($"" +
                $"AccountNo: {acct.AccountNo},\n" +
                $"AccountType: {acct.Accounttype},\n" +
                $"EmailAddress: {acct.emailAddress},\n" +
                $"Balance: {acct.balance},\n" +
                $"CreatedDate: {acct.createddate}");
    */        
    Console.ReadLine();


        }
    }
}
