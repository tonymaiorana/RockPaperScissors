using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Workflows
{
    public class MainMenu
    {
        public void Display()
        {
            string input = "";
            do
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO SGBANK!");
                Console.WriteLine("------------------");
                Console.WriteLine("1. Lookup Account");
                Console.WriteLine("2. Create Account");
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
                    LookupWorkflow lookup = new LookupWorkflow();
                    lookup.Execute();
                    break;
                case "2":
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
        }
    }
}
