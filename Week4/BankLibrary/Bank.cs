using System;
using System.Collections.Generic;
using System.Text;
using BankApp1.BankData;

namespace BankApp1
{
    //Bank Related Field
    public class Bank
    {
        public static List<Customer> AllCustomers = new List<Customer>();

        public static void NewCustomer(string firstName, string password, string Email, string LastName)
        {
            AllCustomers.Add(new Customer(firstName, password, Email, LastName));
        }

        public static void LogIn(string firstName, string password)
        {
            Console.WriteLine("Please enter your Name and your Password");
            Console.WriteLine("First Name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Password: ");
            password = Console.ReadLine();
            foreach (var item in AllCustomers)
            {
                if (item.CustomerFirstName == firstName && item.Password == password)
                {
                    Console.WriteLine("SUCCESSFUL SIGN IN");
                }
                else
                {
                    Console.WriteLine("Invalid FIRSTNAME Or PASSWORD");
                    Console.WriteLine("This Incident will be REPORTED to the ADMIN");
                    throw new ArgumentException(nameof(firstName), "Password Incorrect");
                }
            }
        }
    }



}
