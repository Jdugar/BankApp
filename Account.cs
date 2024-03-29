﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    #region
    ///<summary>
    ///This is enum for account type
    ///</summary>
    enum Typeofaccount
    {
        Checking,
        Saving,
        Loan

    }

    /// <summary>
    /// This is a bank account
    /// </summary>
    class Account
    {
        public decimal amount = 0;
        
        public int AccountNo { get; set; }
        public string  AccountName { get; set; }
        public string EmailAddress { get; set; }
        public Typeofaccount Accounttype { get; set; }
        public decimal balance { get;  set; }
        public DateTime createddate { get;  set; }
        public Account()
        {
            
            createddate = DateTime.Now;
        }
   
        public void Deposit(decimal amt)
        {
           amount = Convert.ToDecimal(amt);
            balance+=amount;
            
        }
        public void Withdraw(decimal amount)
        {
            balance -= amount;
        }

       
        }
    }
    #endregion



