using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSchool
{
    class Discipline
    {
        private string name;
        private int countOfLectures;
        private int countOfExercises;
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

        public int CountOfLectures
        {
            get
            {
                return this.countOfLectures;
            }
            set
            {
                this.countOfLectures = value;
            }
        }

        public int CountOfExercises
        {
            get
            {
                return this.countOfExercises;
            }
            set
            {
                this.CountOfExercises = value;
            }
        }

        public Discipline(string name, int countOfLectures, int countOfExercises, string comment = null)
        {
            this.name = name;
            this.countOfLectures = countOfLectures;
            this.countOfExercises = countOfExercises;
            this.Comments = new Comment();
            this.Comments.AddComment(comment);
        }

        public Discipline(string name)
            : this(name, 0, 0, null)
        {

        }

        public override string ToString()
        {
            string disciplineInformation = "Discipline: " + this.name + " Lectures: " + this.countOfLectures +
                " Exercises: " + this.countOfExercises;
            return disciplineInformation;
        }
    }
}
