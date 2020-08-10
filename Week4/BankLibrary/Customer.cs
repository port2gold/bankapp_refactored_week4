using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BankApp1
{
    //Customer Related Fields
    public class Customer
    {
        private static int CustomerIdSeed = 1;
        public Customer(string firstName, string password, string _Email, string _lastName)
        {
            Password = password;
            CustomerFirstName = firstName;
            CustomerId = CustomerIdSeed.ToString();
            CustomerIdSeed++;
            CustomerEmail = _Email;
            CustomerLastName = _lastName;

        }
        //Customer Constructor
        public Customer()
        {
        }

        public string CustomerId { get; }
        public string Password { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        //Customer Full name 
        //Concatenation of First Name and Last Name
        public string CustomerFullName
        {
            get
            {
                return CustomerLastName + ", " + CustomerFirstName;
            }
        }
        //Account List
        public static List<Account> AllAccount = new List<Account>();

        //Create Account Method
        public void CreateAccount(string name, DateTime date)
        {
            AllAccount.Add(new Account(name, date));
        }




    }
}
