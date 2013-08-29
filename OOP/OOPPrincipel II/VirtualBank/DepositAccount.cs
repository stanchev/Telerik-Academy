using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualBank
{
    class DepositAccount : Account
    {
        public DepositAccount(Customer customer, decimal monthlyInterestRate, decimal balance = 0)
            : base(customer, monthlyInterestRate, balance)
        {

        }

        public void WithDraw(decimal amount)
        {
            if (amount > base.Balance)
            {
                throw new ApplicationException("Not enough money.");
            }
            else
            {
                base.Balance -= amount;
            }
        }

        public override decimal CalculateInterestAmountForGivenTime(int months)
        {
            if (base.Balance >= 0 && base.Balance < 1000)
            {
                return 0;
            }
            return base.CalculateInterestAmountForGivenTime(months);
        }
    }
}
