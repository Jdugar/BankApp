using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {//Insance of an account== object 
            var account = Bank.CreateAccount("testc@gmail.com", Typeofaccount.Checking,$245);
           
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
