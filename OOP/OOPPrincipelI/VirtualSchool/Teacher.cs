using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSchool
{
    class Teacher : People
    {
        private List<Discipline> disciplines;

        public string GetDisciplines
        {
            get
            {
                StringBuilder disciplines = new StringBuilder();
                foreach (Discipline item in this.disciplines)
                {
                    disciplines.AppendLine(item.ToString());
                }
                return disciplines.ToString().Trim();
            }
        }

        public Teacher(string name, string comment = null, params Discipline[] disciplines)
            : base(name, comment)
        {
            this.disciplines = new List<Discipline>();
            if (disciplines != null)
            {
                this.disciplines.AddRange(disciplines);
            }
        }

        public Teacher(string name)
            : this(name, null, null)
        {

        }

        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public override string ToString()
        {
            StringBuilder teacherInfo = new StringBuilder();
            teacherInfo.Append("Teacher: " + base.Name);
            foreach (Discipline item in this.disciplines)
            {
                teacherInfo.Append("  " + item);
            }
            return teacherInfo.ToString();
        }
    }
}
