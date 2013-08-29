using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSchool
{
    class School
    {
        private string name;
        private Dictionary<string, SchoolClass> classes;

        public School(string name)
        {
            this.name = name;
            this.classes = new Dictionary<string, SchoolClass>();
        }

        public void AddClass(SchoolClass schoolClass)
        {
            if (!this.classes.ContainsKey(schoolClass.Name))
            {
                this.classes.Add(schoolClass.Name, schoolClass);
            }
            else
            {
                throw new ApplicationException("Duplicate class name, try with different class name.");
            }
        }

        public string GetAllClasses()
        {
            StringBuilder classes = new StringBuilder();
            foreach (KeyValuePair<string, SchoolClass> item in this.classes)
            {
                classes.AppendLine(item.Key);
            }
            return classes.ToString().Trim();
        }

        public string PrintDetailSchoolInformation()
        {
            StringBuilder schoolInfo = new StringBuilder();
            schoolInfo.AppendLine("School name: " + this.name);
            schoolInfo.AppendLine("--------------");
            foreach (SchoolClass schoolClass in this.classes.Values)
            {
                schoolInfo.AppendLine("Class name: " + schoolClass.Name);
                schoolInfo.AppendLine("Students: ");
                schoolInfo.AppendLine(schoolClass.GetStudentsInformation());
                schoolInfo.AppendLine("Teachers: ");
                schoolInfo.AppendLine(schoolClass.GetTeachersInformation());
                schoolInfo.AppendLine("--------------");
            }
            return schoolInfo.ToString();
        }
    }
}
