using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualBank
{
    class CompanyCustomer : Customer
    {
        private string bulstat;

        public string Bulstat
        {
            get { return this.bulstat; }
            set { this.bulstat = value; }
        }

        public CompanyCustomer(string companyName, string bulstat, string address, string telephoneNumber)
            : base(companyName, address, telephoneNumber)
        {
            this.bulstat = bulstat;
        }

        public override string ToString()
        {
            string companyInfo = base.ToString() + "Bulstat: " + this.bulstat + Environment.NewLine;
            return companyInfo;
        }
    }
}
