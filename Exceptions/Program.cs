using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KKB.Bank.Module;



namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            string Login = "";
            string Password = "";

            try
            {
                Client cl = new Client();
                Service.CreateClient(ref cl);
                cl.Login = "admin";
                cl.Password = "admin";

                while (!cl.isBlocked)
                {
                    Console.Clear();
                    Console.Write("Sign in \n");
                    Login = Console.ReadLine();
                    Console.Write("Enter a password \n");
                    Password = Console.ReadLine();

                    if (Login != cl.Login && Password != cl.Password)
                    {
                        cl.WrongField--;
                        Console.WriteLine("Invalid Password. You have {0} attemps", cl.WrongField);
                        Console.ReadKey();
                    }
                    else
                        break;
                }


                if (Login == cl.Login && Password == cl.Password)
                {
                    if (cl.isBlocked)
                    {
                        Console.WriteLine("User is blocked! ");
                    }
                    else
                    {
                        #region
                        Console.Clear();

                        Console.WriteLine("1. Checks lists");
                        Console.WriteLine("2. Create a check");
                        Console.WriteLine("3. Add to balance");
                        Console.WriteLine("4. Withdraw money from account");
                        Console.WriteLine("6. Exit");
                        int MenuChoice = 0;
                        Int32.TryParse(Console.ReadLine(), out MenuChoice);
                        if (MenuChoice > 6 || MenuChoice < 1)
                        {
                            throw new Exception("Invalid choice");
                        }
                        else
                        {
                            switch (MenuChoice)
                            {
                                case 1:
                                    {
                                        cl.PrintAccount();
                                        int choice = 0;
                                        Console.WriteLine("Enter any digit for return to menu or 0 for exit");
                                        Int32.TryParse(Console.ReadLine(), out choice);
                                        if (choice == 0)
                                            return;
                                        else
                                            break;
                                    }
                                  
                                case 2:
                                    {
                                        try
                                        {
                                            Account acc = Service.CreateAccountList();
                                            cl.ListAccount.Add(acc);
                                            Console.WriteLine("Your account was succesfully added!");
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                        int choice = 0;
                                        Console.WriteLine("Enter any digit for return to menu or 0 for exit");
                                        Int32.TryParse(Console.ReadLine(), out choice);
                                        if (choice == 0)
                                            return;
                                        else
                                            break;
                                    }
                                  
                                case 3:
                                    {
                                        
                                        Console.WriteLine("Enter your account number ");
                                        string accountNumber = Console.ReadLine();
                                        Console.WriteLine("Pls enter a summ");
                                        string accountSum = Console.ReadLine();
                                        try
                                        {
                                            foreach (var item in cl.ListAccount)
                                            {
                                                if (item.AccountNumber == accountNumber)
                                                {
                                                    item.Balance += double.Parse(accountSum);
                                                    Console.WriteLine("The account {0} was successfully replenished for the amount of {1}", accountNumber, accountSum);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                        int choice = 0;
                                        Console.WriteLine("Enter any digit for return to menu or 0 for exit");
                                        Int32.TryParse(Console.ReadLine(), out choice);
                                        if (choice == 0)
                                            return;
                                        else
                                            break;

                                    }
                                case 4:
                                    {
                                        Console.WriteLine("Enter your account number ");
                                        string accountNumber = Console.ReadLine();
                                        Console.WriteLine("Pls enter a summ");
                                        string accountSum = Console.ReadLine();
                                        try
                                        {
                                            foreach (var item in cl.ListAccount)
                                            {
                                                if (item.AccountNumber == accountNumber)
                                                {
                                                    if (double.Parse(accountSum) > item.Balance)
                                                    {
                                                        Console.WriteLine("The summ you've entered is higher than exists on the account");
                                                    }
                                                    else
                                                    {
                                                        item.Balance -= double.Parse(accountSum);
                                                        Console.WriteLine("The summ{0} was successfully withdrawn from the account{1}", accountSum, accountNumber);
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                       
                                        int choice = 0;
                                        Console.WriteLine("Enter any digit for return to menu or 0 for exit");
                                        Int32.TryParse(Console.ReadLine(), out choice);
                                        if (choice == 0)
                                            return;
                                        else
                                            break;
                                    }

                                case 6:
                                    return;
                                   
                            }
                        }
                        #endregion
                    }
                }
                else
                {
                    Console.WriteLine("User blocked!");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
            /* List<Client> ListClient = new List<Client>();
                 GeneratorName.Generator gn = new Generator();
                 Client client = new Client();
                 client.DoB = DateTime.Now.AddYears(-60);
                 client.FullName = gn.GenerateDefault(Gender.man);
                 client.IIN = "123456789123";
                 client.Login = "Qwerty";
                 client.Password = "123";
                 client.PhoneNumber = "87651684585";
                 ListClient.Add(client);*/


        }
    }
}