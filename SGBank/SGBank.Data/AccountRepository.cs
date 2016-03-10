using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.Data
{
    public class AccountRepository
    {
        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();

            string filePath = ConfigurationManager.AppSettings["FileName"];

            var reader = File.ReadAllLines(filePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var account = new Account();
                account.AccountNumber = int.Parse(columns[0]);
                account.FirstName = columns[1];
                account.LastName = columns[2];
                account.Balance = decimal.Parse(columns[3]);

                accounts.Add(account);
            }

            return accounts;
        }

        public Account GetAccountByNumber(int accountNumber)
        {
            List<Account> accounts = GetAllAccounts();
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }
    }
}
