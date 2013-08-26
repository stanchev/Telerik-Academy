using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSchool
{
    abstract class Comment
    {
        private List<string> comments;

        public Comment()
        {
            this.comments = new List<string>();
        }

        public void AddComment(string comment)
        {
            if (comment != null)
            {
                this.comments.Add(comment);                
            }
        }

        public string[] GetComments
        {
            get
            {
                return this.comments.ToArray();
            }
        }
    }
}
