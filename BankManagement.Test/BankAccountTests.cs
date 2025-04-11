using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingManagement.Test
{
    public class BankAccountTests
    {
        [Fact]
        public void DepositTest()
        {
            BankAccount test = new BankAccount("test", 1000, 1000);
            test.MakeDeposit(500,DateTime.Now,"1ST DEPOSIT");

            var bal = test.Balance;

            Assert.Equal(500, bal);
        }
        public void MakeWithdrawalTest1()
        {
            BankAccount test1=new BankAccount("test1", 1000 , 1000);
            test1.MakeWithdrawal(200, DateTime.Now, "1st withdrawal");

            var bal = test1.Balance;
            Assert.Equal(800, bal);
        }

    }
}
