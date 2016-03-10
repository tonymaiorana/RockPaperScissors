using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.Workflows
{
    public class LookupWorkflow
    {
        private Account _currentAccount;

        public void Execute()
        {
            //I need to get the account number from the user
            int accountNumber = GetAccountNumberFromUser();

            //I need to display the account returned to the user
            DisplayAccountInformation(accountNumber);

        }

        private int GetAccountNumberFromUser()
        {
            do
            {
                Console.Clear();
                Console.Write("Enter an account number: ");
                string input = Console.ReadLine();

                int accountNumber;
                if (int.TryParse(input, out accountNumber))
                {
                    return accountNumber;
                }

                Console.WriteLine("That was not a valid account number...");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            } while (true);
        }

        private void DisplayAccountInformation(int accountNumber)
        {
            var ops = new AccountOperations();
            var response = ops.GetAccount(accountNumber);

            if (response.Success)
            {
                _currentAccount = response.AccountInfo;
                //Print account info
                PrintAccountInformation();

                DisplayAccountMenu();
            }
            else
            {
                //Crap, we got an error!
                Console.WriteLine("Error occurred!!");
                Console.WriteLine(response.Message);
                Console.WriteLine("Move Along...");
                Console.ReadLine();
            }
        }

        private void PrintAccountInformation()
        {
            Console.Clear();
            Console.WriteLine("Account Information");
            Console.WriteLine("-------------------");
            Console.WriteLine("Account Number: {0}", _currentAccount.AccountNumber);
            Console.WriteLine("Name: {0}, {1}", _currentAccount.LastName, _currentAccount.FirstName);
            Console.WriteLine("Account Balance: {0:c}", _currentAccount.Balance);
        }

        private void DisplayAccountMenu()
        {
            string input = "";

            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Close Account");
                Console.WriteLine();
                Console.WriteLine("(Q) to Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Enter Choice: ");

                input = Console.ReadLine();

                if (input.ToUpper() != "Q")
                {
                    ProcessChoice(input);
                }

            } while (input.ToUpper() != "Q");
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                    Console.WriteLine("This feature is not implemented yet!");
                    Console.WriteLine("Press Enter to Continue...");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("{0} is not valid!", choice);
                    Console.WriteLine("Press Enter to Continue...");
                    Console.ReadLine();
                    break;
            }

            PrintAccountInformation();
        }
    }
}
