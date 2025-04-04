using System;
using System.ComponentModel.DataAnnotations;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("welcome to Saahil's Bank");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Print all account");
                Console.WriteLine("5. Print all Transactions");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting my Bank");
                        return;
                    case "1":
                        Console.WriteLine("Enter the email account");
                        var email = Console.ReadLine();
                        Console.Write("Enter Account name");
                        var accountname = Console.ReadLine();
                        Console.WriteLine("Select the AccountType");
                        var acctype = Enum.GetNames(typeof(Typeofaccount));
                        for (int i = 0; i < acctype.Length; i++)
                        {
                            Console.WriteLine($"{i}.{acctype[i]}");
                        }
                        var accounttype = Enum.Parse<Typeofaccount>(Console.ReadLine());
                        Console.WriteLine("initial Deposit");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        
                       

                        var account = Bank.CreateAccount(email,accountname, accounttype, amount);
                        Console.WriteLine($"Account No: {account.AccountNo},Created Date:{account.createddate}," +
                            $"Email Address:{ account.EmailAddress}, Account Type:{account.Accounttype}, Balance:{account.amount:C}");


                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Select the Account No:"  );
                        var accountNo = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the amount to deposited:");
                         amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNo,amount);

                        Console.WriteLine("Deposited completed successfully");
                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.Write("Select the Account No:");
                        accountNo = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the amount to withdraw:");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(accountNo, amount);

                        Console.WriteLine("Withdraw completed successfully");
                        break;
                        
                    case "4":
                        
                        PrintAllAccounts();
                        break;
                    case "5":
                        PrintAllAccounts();
                        Console.Write("Select the Account No:");
                        accountNo = Convert.ToInt32(Console.ReadLine());
                        var transaction = Bank.GetAllTransactionsbyAccountNunber(accountNo);
                        foreach (var mytransaction in transaction)
                        {
                            Console.WriteLine($"\nTransaction id: {mytransaction.ID}, \nTransaction Date:{mytransaction.TransactionDate}, " +
                           $"\n:Transaction Type{ mytransaction.TransactionType}, \nAccount No:{mytransaction.AccountNumber}, \nAccount Balance:{mytransaction.Balance:C}, \nAmount:{mytransaction.Amount:C}");

                        }
                        break;

                    default:
                        Console.WriteLine("Please select the valid option");
                        break;
                }
            }
        }

        private static string PrintAllAccounts()
        {
            string email;
            Console.Write("enter the email address:");
            email = Console.ReadLine();
           var accounts = Bank.GetAllAccountsbyEmailAddress(email);
            foreach (var myaccount in accounts)
            {
                Console.WriteLine($"\nAccount No: {myaccount.AccountNo}, \nCreated Date:{myaccount.createddate}, " +
               $"\nEmail Address:{ myaccount.EmailAddress}, \nAccount Type:{myaccount.Accounttype}, \nAccount Balance:{myaccount.balance}, \nAmount:{myaccount.amount:C}");

            }

            return email;
        }
    }
}
