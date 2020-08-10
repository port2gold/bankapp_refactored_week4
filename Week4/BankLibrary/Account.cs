using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace BankApp1
{
    //Account Related Fields
    public class Account
    {
        private static int AccountNumberSeed = 1234567890;


        public string AccountNumber { get; }
        public string AccountOwner { get; }
        public string AccountType = "Savings";
        public DateTime DateCreated { get; }

        //Account Balance
        public decimal AccountBalance
        {
            get
            {
                decimal AccountBalance = 0;
                foreach (var item in AllTransactions)
                {
                    AccountBalance += item.Amount;
                }
                return AccountBalance;
            }
            private set { }
        }
        public Account(string name, DateTime date)
        {

            AccountNumber = AccountNumberSeed.ToString();
            AccountNumberSeed++;
            DateCreated = date;
            AccountOwner = name;
        }
        public List<Transactions> AllTransactions = new List<Transactions>();
        public void Deposit(decimal amount, DateTime date, string note)
        {
            // AccountBalance += amount;
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Positive Amount Only!");
            }
            var deposit = new Transactions(amount, date, note);
            AllTransactions.Add(deposit);
        }
        //All Transactions List and  Account Withdrawal
        public void Withdrawal(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Positive Amount Only!");
            }
            if (AccountBalance - amount < 100)
            {
                throw new ArgumentOutOfRangeException("You don't have sufficient funds");
            }

            var withdrawal = new Transactions(-amount, date, note);
            AllTransactions.Add(withdrawal);

        }
        //Account Balance Check

        public string Balance()
        {
            return this.AccountBalance.ToString();
        }
        //Transfer

        public void Transfer(string _AccountNumber, decimal amount, DateTime date, string note)
        {
            foreach (var item in Customer.AllAccount)
            {
                if (item.AccountNumber == _AccountNumber)
                {
                    item.Deposit(amount, DateTime.Now, note);
                }
                this.Withdrawal(amount, DateTime.Now, note);
            }

        }



    }
}
