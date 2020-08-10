using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp1
{
    //Transactions Related fields
    public class Transactions
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        //Transactions Constructor

        public Transactions(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }
    }
}
