using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.BLL
{
    public class AccountOperations
    {
        public Response GetAccount(int accountNumber)
        {
           var repo = new AccountRepository();
            
            var response = new Response();

            var account = repo.GetAccountByNumber(accountNumber);

            if (account == null)
            {
                response.Success = false;
                response.Message = "This is not the Account you are looking for...";
            }
            else
            {
                response.Success = true;
                response.AccountInfo = account;
            }

            return response;
        }

        public decimal Deposit(int accountNumber)
        {   
            
        }
    }
}
