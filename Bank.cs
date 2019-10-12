using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    static class Bank                         
    {                                                 
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

            return acct;
        }
    }
}
