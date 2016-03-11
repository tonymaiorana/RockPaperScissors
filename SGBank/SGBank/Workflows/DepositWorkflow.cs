using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.Workflows
{
    public class DepositWorkflow
    {
        private Account _currentAccount;
        public DepositWorkflow(Account account)
        {
            _currentAccount = account;
        }
        public Account MakeDeposit()
        {
            decimal amount = PromptUserForDeposit();
            var ops = new AccountOperations();
            ops.MakeDeposit(_currentAccount, amount);
            return _currentAccount;
        }

        public decimal PromptUserForDeposit()
        {
            do
            {
                Console.Write("Enter the amount of your deposit: ");
                string input = Console.ReadLine();

                decimal depositAmount;
                if (decimal.TryParse(input, out depositAmount))
                {
                    return depositAmount;
                }

                Console.WriteLine("That is not a valid deposit amount...");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            } while (true);
        }
    }
}
