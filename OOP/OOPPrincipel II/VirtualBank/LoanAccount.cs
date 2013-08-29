using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualBank
{
    class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal monthlyInterestRate, decimal balance = 0)
            : base(customer, monthlyInterestRate, balance)
        {

        }

        public override decimal CalculateInterestAmountForGivenTime(int months)
        {
            if ((base.Customer is IndividualCustomer && months <= 3) ||
                (base.Customer is CompanyCustomer && months <= 2))
            {
                return 0;
            }
            months = base.Customer is IndividualCustomer ? months - 3 : months - 2;
            return base.CalculateInterestAmountForGivenTime(months);
        }
    }
}
