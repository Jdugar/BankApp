using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
   static class Bank
    {
        public static Account createAccount(String emailaddress, Typeofaccount accounttype ,Decimal intialdeposit)
        {
            var account = new Account
            {
                EmailAddress = emailaddress,
                Accounttype = accounttype,
            };
            if(intialdeposit>0)
            {
                account.Deposit(intialdeposit);
            }return account;
        }
    }
}
