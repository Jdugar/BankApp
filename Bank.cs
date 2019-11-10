using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Transactions;

namespace BankApp
{
    static class Bank
    {
        private static BankContext db = new BankContext();

        public static Account CreateAccount(String em,string accountname, Typeofaccount aType =Typeofaccount.Checking, Decimal amountToBeDeposited=0)
        {
            var acct = new Account
            {
                AccountName=accountname,
                EmailAddress = em,
                Accounttype = aType,
            };
            if (amountToBeDeposited > 0)
            {
                acct.Deposit(amountToBeDeposited);
            }
            db.Accounts.Add(acct);
            db.SaveChanges();
            return acct;
        }
        public static IEnumerable<Account> GetAllAccountsbyEmailAddress(string Emailaddress)
        {
            return db.Accounts.Where(a => a.EmailAddress == Emailaddress);
        }
        public static IEnumerable<Transaction> GetAllTransactionsbyAccountNunber(int accountnumber)
        {
            return db.Transactions.Where(a => a.AccountNumber == accountnumber);
        }
            public static void Deposit(int accountnumber, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNo == accountnumber);
            if (account == null)
            {
                return;
            }
            account.Deposit(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Amount = amount,
                TransactionType = TypesofTransaction.debit,
                Description = "Bank Deposit",
                Balance = account.balance,
                AccountNumber = accountnumber

            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
        public static void Withdraw(int accountnumber, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNo == accountnumber);
            if (account == null)
            {
                return;
            }
            account.Withdraw(amount);
            var transaction1 = new Transaction
            {
                TransactionDate = DateTime.Now,
                Amount = amount,
                TransactionType = TypesofTransaction.credit,
                Description = "Bank Withdraw",
                Balance = account.balance,
                AccountNumber = accountnumber

            };
            db.Transactions.Add(transaction1);
            db.SaveChanges();
        }

    }
}
