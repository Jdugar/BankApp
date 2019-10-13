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

                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting my Bank");
                        return;
                    case "1":
                        Console.WriteLine("Enter the email account");
                        var email = Console.ReadLine();
                        Console.WriteLine("Select the AccountType");
                        var acctype = Enum.GetNames(typeof(Typeofaccount));
                        for (int i = 0; i < acctype.Length; i++)
                        {
                            Console.WriteLine($"{i}.{acctype[i]}");
                        }
                        var accounttype = Enum.Parse<Typeofaccount>(Console.ReadLine());
                        Console.WriteLine("initial Deposit");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        var account = Bank.CreateAccount(email, accounttype, amount);
                        Console.WriteLine($"Account No: {account.AccountNo},Created Date:{account.createddate}," +
                            $"Email Address:{ account.EmailAddress}, Account Type:{account.Accounttype}, Balance:{account.amount:C}");


                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Select the Account No:"  );
                        var accountNo = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the amount to deposited:");
                         amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNo,  amount);

                        Console.WriteLine("Deposited completed successfully");
                        break;
                    case "3":
                        break;
                    case "4":
                        email = PrintAllAccounts();
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
                Console.WriteLine($"Account No: {myaccount.AccountNo},Created Date:{myaccount.createddate}," +
               $"Email Address:{ myaccount.EmailAddress}, Account Type:{myaccount.Accounttype}, Balance:{myaccount.amount:C}");

            }

            return email;
        }
    }
}
