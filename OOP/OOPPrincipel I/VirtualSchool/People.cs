using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSchool
{
    class People
    {
        private string name;
        public Comment Comments { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public People(string name, string comment = null)
        {
            this.name = name;
            this.Comments = new Comment();
            this.Comments.AddComment(comment);
        }
    }
}
