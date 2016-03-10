using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.Data;

namespace SGBank.Tests
{
    [TestFixture]
    public class AccountRepositoryTests
    {
        [Test]
        public void CanLoadAccount()
        {
            var repo = new AccountRepository();

            var account = repo.GetAccountByNumber(1);

            Assert.AreEqual(1, account.AccountNumber);
            Assert.AreEqual("George", account.FirstName);
        }
    }
}
