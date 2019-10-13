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
        private static List<Account> accounts = new List<Account>();
        private static List<Transaction> transactions = new List<Transaction>();

        public static Account CreateAccount(String em, Typeofaccount aType, Decimal amountToBeDeposited)
        {
            var acct = new Account
            {
                EmailAddress = em,
                Accounttype = aType,
            };
            if (amountToBeDeposited > 0)
            {
                acct.Deposit(amountToBeDeposited);
            }
            accounts.Add(acct);
            return acct;
        }
        public static IEnumerable<Account> GetAllAccountsbyEmailAddress(string Emailaddress)
        {
            return accounts.Where(a => a.EmailAddress == Emailaddress);
        }
        public static void Deposit(int accountnumber, decimal amount)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNo == accountnumber);
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
            transactions.Add(transaction);
        }
        public static void Withdraw(int accountnumber, decimal amount)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNo == accountnumber);
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
            transactions.Add(transaction1);
        }

    }
}
