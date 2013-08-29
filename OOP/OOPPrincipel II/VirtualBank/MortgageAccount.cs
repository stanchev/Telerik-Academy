using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualBank
{
    class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal monthlyInterestRate, decimal balance = 0)
            : base(customer, monthlyInterestRate, balance)
        {

        }

        public override decimal CalculateInterestAmountForGivenTime(int months)
        {
            if (base.Customer is IndividualCustomer)
            {
                if (months <= 6)
                {
                    return 0;
                }
                else
                {
                    return base.CalculateInterestAmountForGivenTime(months - 6);
                }
            }
            else if (base.Customer is CompanyCustomer)
            {
                decimal halfInterest = months > 12 ? base.CalculateInterestAmountForGivenTime(12) * 0.5m : 
                    base.CalculateInterestAmountForGivenTime(months) * 0.5m;
                if (months <= 12)
                {
                    return halfInterest;
                }
                else
                {
                    return base.CalculateInterestAmountForGivenTime(months - 12) + halfInterest;
                }
            }
            else
            {
                throw new ApplicationException("Unknown customer type.");
            }
        }
    }
}
