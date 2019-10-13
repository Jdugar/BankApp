using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    enum TypesofTransaction
    {
        credit,
        debit
    } 
    class Transaction
    {
        public int ID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public TypesofTransaction TransactionType { get; set; }
        public decimal Balance { get; set; }

        public int AccountNumber { get; set; }
    }
}
