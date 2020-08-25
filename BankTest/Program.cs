using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;

namespace BankTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            do
            {
                bool showEnd = true;

                Console.Clear();

                Console.WriteLine("Bank ATM");
                ShowDivider();

                Console.WriteLine("1. Login");
                Console.WriteLine("2. Exit");

                char userInput = Console.ReadKey().KeyChar;

                if (userInput == '1')
                {
                    UserHandler userHandler = new UserHandler();
                    bool incorrectPin = true;
                    byte numberofTries = 0;

                    do
                    {
                        Console.Clear();
                        Console.Write("Pin: ");
                        string pinCode = Console.ReadLine();

                        if (userHandler.Login(pinCode))
                        {
                            incorrectPin = false;
                        }
                        else
                        {
                            if(numberofTries < 3)
                            {
                                numberofTries++;
                                Console.WriteLine($"Invalid Pin. Please try again. Try number {numberofTries} / 3");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine($"Too many incorrect attempts. Closing application.");
                                showMenu = false;
                            }

                        }

                    } while (incorrectPin & showMenu);


                    // Main menu
                    if (userHandler.LoggedIn())
                    {
                        bool showMainMenu = true;
                        do
                        {
                            DisplayMainMenu();

                            userInput = Console.ReadKey().KeyChar;

                            switch (userInput)
                            {
                                // Show Balance
                                case '1':
                                    Console.Clear();
                                    Console.WriteLine("Here is your current balance:");
                                    ShowDivider();
                                    Console.WriteLine("   " + BankHandler.ShowBalance(userHandler.CurrentUser));

                                    Console.WriteLine();
                                    ShowContinue();

                                    break;

                                // Add to Balance
                                case '2':
                                    Console.Clear();
                                    Console.WriteLine("Add to balance:");
                                    ShowDivider();
                                    Console.Write("   Add amount: ");

                                    string addToBalanceUserInput = Console.ReadLine();

                                    try
                                    {
                                        BankHandler.AddToBalance( userHandler.CurrentUser, decimal.Parse(addToBalanceUserInput) );
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("An error ocured...");
                                        ShowContinue();
                                    }


                                    break;


                                // Withdraw from Balance
                                case '3':

                                    Console.Clear();
                                    Console.WriteLine("Withdraw from Balance:");
                                    ShowDivider();
                                    Console.Write("   Withdraw amount: ");

                                    string withdrawFromBalanceUserInput = Console.ReadLine();

                                    try
                                    {
                                        BankHandler.WithdrawFromBalance(userHandler.CurrentUser, decimal.Parse(withdrawFromBalanceUserInput));
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("An error ocured...");                                        
                                        ShowContinue();
                                    }

                                    break;

                                case '4':

                                    showMainMenu = false;
                                    showEnd = false;

                                    break;
                                default:
                                    break;
                            }


                        } while (showMainMenu);
                        

                    }

                }
                else if (userInput == '2')
                {
                    showMenu = false;
                    showEnd = false;

                }


                if (showEnd)
                {
                    ShowContinue();
                }

            } while (showMenu);
        }

        static void ShowDivider()
        {
            Console.WriteLine("___________________");
            Console.WriteLine();
        }

        static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Show Balance");
            Console.WriteLine("2. Add to Balance");
            Console.WriteLine("3. Withdraw from Balance");
            Console.WriteLine("4. Exit");
        }

        static void ShowContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}
