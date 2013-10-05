using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualBank
{
    abstract class Account
    {
        private Customer customer;
        private decimal balance;
        private decimal monthlyInterestRate;

        public Customer Customer
        {
            get { return this.customer; }
            set { this.customer = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            protected set { this.balance = value; }
        }

        public decimal MonthlyInterestRate
        {
            get { return this.monthlyInterestRate; }
            set
            {
                if (value > 100)
                {
                    throw new ApplicationException("Monathly interest rate must be 0-100 percent.");
                }
                else
                {
                    this.monthlyInterestRate = value;
                }
            }
        }

        public Account(Customer customer, decimal monthlyInterestRate, decimal balance = 0)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.MonthlyInterestRate = monthlyInterestRate;
        }

        public void AddDeposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ApplicationException("Deposit amount can't be negative.");
            }
            else
            {
                this.balance += amount;
            }
        }

        public virtual decimal CalculateInterestAmountForGivenTime(int months)
        {
            return months * this.monthlyInterestRate;
        }
    }
}
