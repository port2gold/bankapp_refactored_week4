using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace BankApp1
{
    class Program
    {

        static void Main(string[] args)
        {


            bool bank_session = true;
            while (bank_session == true)
            {
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("Welcome to the Most Wonderful Bank");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("What Would you like to do?");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");


                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

                Console.WriteLine("To Register Press ====================>          1");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

                Console.WriteLine("To Log In Press ======================>          2");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

                Console.WriteLine("To Exit our wonderful Bank Press ===============> 3");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

                Console.WriteLine("INPUT: ");
                int response = Convert.ToInt32(Console.ReadLine());
                if (response < 1 && response > 2)
                {

                    throw new ArgumentOutOfRangeException(nameof(response), "Please Input  1    ,     2     or  3");
                }
                // Regiser  and Create an Account
                if (response == 1)
                {
                    Console.WriteLine("Enter your First Name: ");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Enter your LastName: ");
                    string lastName = Console.ReadLine();

                    Console.WriteLine("Enter your Email: ");
                    string Email = Console.ReadLine();

                    Console.WriteLine("Enter your Password");
                    string password = Console.ReadLine();
                    Bank.NewCustomer(firstName, password, Email, lastName);
                    Console.WriteLine("Successfully Registered!!!");

                    //Account Creation

                    foreach (var items in Bank.AllCustomers)
                    {
                        if (items.CustomerFirstName == firstName)
                        {
                            items.CreateAccount(items.CustomerFullName, DateTime.Now);
                            Console.WriteLine("Account Creation Successful");
                            foreach (var item in Customer.AllAccount)
                            {
                                for (int i = 0; i < Customer.AllAccount.Count; i++)
                                {
                                    if (Customer.AllAccount[i].AccountOwner == items.CustomerFullName)
                                    {
                                        Console.WriteLine($"Your Account Number is {Customer.AllAccount[i].AccountNumber}");

                                    }
                                }


                            }
                        }
                    }
                }
                //LOG IN
                else if (response == 2)
                {
                    Console.WriteLine("Please Enter your  First Name and your Password Twice: ");
                    Console.WriteLine("FIRST NAME: ");
                    string firstName1 = Console.ReadLine();
                    Console.WriteLine("PASSWORD: ");
                    string password1 = Console.ReadLine();
                    Bank.LogIn(firstName1, password1);

                    //Bank Options
                    bool signIn = true;
                    while (signIn == true)
                    {

                        Console.WriteLine("==========(DEPOSIT) =======================> PRESS  1");
                        Console.WriteLine("==========(TRANSFER) ======================> PRESS  2");
                        Console.WriteLine("==========(BALANCE) =======================> PRESS  3");
                        Console.WriteLine(" =========(WITHDRAWAL)======================> PRESS  4");
                        Console.WriteLine(" =======(OPEN ANOTHER ACCOUNT)==============> PRESS  5");
                        Console.WriteLine("========(ACCOUNT HISTORY)===================> PRESS  6");
                        Console.WriteLine("===========(LOG OUT=========================> PRESS  7");
                        int answer = Convert.ToInt32(Console.ReadLine());

                        // Deposit
                        if (answer == 1)
                        {
                            // foreach (var item in Bank.AllCustomers)
                            {
                                Console.WriteLine("Enter Account Number: ");
                                string accountNumber = Console.ReadLine();


                                Console.WriteLine("Enter the Amount to Deposit: ");
                                decimal amount = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Note: ");
                                string note = Console.ReadLine();
                                for (int i = 0; i < Customer.AllAccount.Count; i++)
                                {
                                    if (Customer.AllAccount[i].AccountNumber == accountNumber)
                                    {
                                        Customer.AllAccount[i].Deposit(amount, DateTime.Now, note);
                                    }
                                }
                            }
                        }
                        //Transfer
                        else if (answer == 2)
                        {
                            {
                                Console.WriteLine("Enter Receiver Account Number: ");
                                string accountNumber1 = Console.ReadLine();
                                Console.WriteLine("Enter Your Account Number: ");
                                string accountNumber2 = Console.ReadLine();


                                Console.WriteLine("Enter the Amount to Deposit: ");
                                decimal amount = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Note: ");
                                string note = Console.ReadLine();
                                for (int i = 0; i < Customer.AllAccount.Count; i++)
                                {
                                    if (Customer.AllAccount[i].AccountNumber == accountNumber1)
                                    {
                                        Customer.AllAccount[i].Deposit(amount, DateTime.Now, note);
                                    }

                                    if (Customer.AllAccount[i].AccountNumber == accountNumber2)
                                    {
                                        Customer.AllAccount[i].Withdrawal(amount, DateTime.Now, note);
                                    }
                                }
                            }
                        }

                        //Balance

                        else if (answer == 3)
                        {
                            Console.WriteLine("Enter Your Account Number: ");
                            string _accountNumber = Console.ReadLine();
                            foreach (var item in Customer.AllAccount)
                            {
                                if (item.AccountNumber == _accountNumber)
                                {
                                    item.Balance();
                                }
                            }
                        }


                        //WITHDRAWAL

                        else if (answer == 4)
                        {
                            Console.WriteLine("Enter the Amount to Withdraw: ");
                            decimal amount = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Note: ");
                            string note = Console.ReadLine();
                            Console.WriteLine("Enter Your Account Number: ");
                            string _accountNumber = Console.ReadLine();
                            foreach (var item in Customer.AllAccount)
                            {
                                if (item.AccountNumber == _accountNumber)
                                {
                                    item.Withdrawal(amount, DateTime.Now, note);
                                }
                            }
                        }

                        //Create Multiple Accounts

                        else if (answer == 5)
                        {
                            Console.WriteLine("ENTER YOUR FIRST NAME");
                            string _firstName = Console.ReadLine();
                            foreach (var item in Bank.AllCustomers)
                            {
                                if (item.CustomerFirstName == _firstName)
                                {
                                    item.CreateAccount(item.CustomerFullName, DateTime.Now);
                                }
                            }
                        }

                        //Account History

                        else if (answer == 6)
                        {
                            Console.WriteLine("To check your Account History: ");
                            Console.WriteLine("ENTER YOUR ACCOUNT NUMBER: ");
                            string _accountNumber = Console.ReadLine();
                            foreach (var item in Customer.AllAccount)
                            {
                                if (item.AccountNumber == _accountNumber)
                                {
                                    foreach (var items in item.AllTransactions)
                                    {
                                        Console.WriteLine("     Full Name               Account Number          AccountType             Amount        Account Balance       Note        Dates");
                                        Console.WriteLine($"{item.AccountOwner}     {item.AccountNumber}    {item.AccountType}     {items.Amount}       {item.AccountBalance}    {items.Notes}   {items.Date}");
                                    }
                                }
                            }

                        }


                        //SIGN OUT

                        else
                        {
                            signIn = false;
                        }

                    }


                }
                else
                {
                    bank_session = false;
                }

            }

        }



    }

}












