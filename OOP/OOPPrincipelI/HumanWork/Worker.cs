using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanWork
{
    class Worker : Human
    {
        public double WeekSalary { get; set; }
        public double WorkHoursPerDay { get; set; }

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public Worker(string firstName, string lastName)
            : this(firstName, lastName, 0, 0)
        {

        }

        public double MoneyPerHour()
        {
            int workingDays = 5;
            double moneyPerHour = this.WeekSalary / (this.WorkHoursPerDay * workingDays);
            return moneyPerHour;
        }

        public override string ToString()
        {
            return base.ToString() + " money per hour: " + this.MoneyPerHour();
        }
    }
}
