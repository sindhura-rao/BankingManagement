﻿using System;
using Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingManagement
{
    public class LineOfCreditAccount : BankAccount
    { 
        public LineOfCreditAccount(string name, decimal initialBalance) : base(name, initialBalance)
        { }
        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                // Negate the balance to get a positive interest charge:
                decimal interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }
    }
    }

