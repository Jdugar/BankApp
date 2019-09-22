﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    #region 

    /// <summary>
    /// This is a bank account
    /// </summary>
    class Account
    {
        public decimal amount = 0;
        public static int lastAccountNo = 0;
        public int AccountNo { get; set; }
        public string emailAddress { get; set; }
        public String Accounttype { get; set; }
        public decimal balance { get; private set; }
        public DateTime createddate { get; private set; }
        public Account()
        {
            AccountNo = ++lastAccountNo;
            createddate = DateTime.Now;
        }
        public void Deposit()
        {

            Console.WriteLine("enter the deposit amount");
            var input = Console.ReadLine();
            amount = Convert.ToInt32(input);
            balance += amount;

        }
        public void Print()
        {
            Console.WriteLine($"" +
               $"AccountNo: {AccountNo},\n" +
               $"AccountType: {Accounttype},\n" +
               $"EmailAddress: {emailAddress},\n" +
               $"Balance: {balance},\n" +
               $"CreatedDate: {createddate}");

        }
    }
    #endregion


}
