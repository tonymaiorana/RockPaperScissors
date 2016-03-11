using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
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
                return accounts;
            }
        }

        public Account GetAccountByNumber(int accountNumber)
        {
            List<Account> accounts = GetAllAccounts();
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public void UpdateAccount(Account account)
        {
            var accounts = GetAllAccounts();

            var accountToUpdate = accounts.Where(a => a.AccountNumber == account.AccountNumber)
                .FirstOrDefault();

            accountToUpdate.Balance = account.Balance;

            WriteFile(accounts);
        }

        private void WriteFile(List<Account> accounts)
        {
            string filePath = ConfigurationManager.AppSettings["FileName"];

            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine("Account Number, First Name, Last Name, Balance");
                foreach (var account in accounts)
                {
                    sw.WriteLine("{0}, {1}, {2}, {3}", account.AccountNumber, account.LastName, account.FirstName,
                        account.Balance);
                }
            }
        }
    }
}
