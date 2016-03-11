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
        public void MakeDeposit()
        {
            decimal amount = PromptUserForDeposit();
            var ops = new AccountOperations();
            ops.MakeDeposit(_currentAccount, amount);
        }

        public decimal PromptUserForDeposit()
        {
            
        }
    }
}
