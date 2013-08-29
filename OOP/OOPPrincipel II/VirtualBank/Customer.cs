using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualBank
{
    abstract class Customer
    {
        private string name;
        private string address;
        private string telephoneNumber;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public string TelephoneNumber
        {
            get { return this.telephoneNumber; }
            set { this.telephoneNumber = value; }
        }

        protected Customer(string name, string address, string telephoneNumber)
        {
            this.name = name;
            this.address = address;
            this.telephoneNumber = telephoneNumber;
        }

        public override string ToString()
        {
            string customerInfo = string.Format("Name: {0}\nAddress: {1}\nTel. number: {2}\n",
                this.name,this.address,this.telephoneNumber);
            return customerInfo;
        }
    }
}
