using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS3033_004_EX3
{
    public class Student
    {
        public string ID { get; set; }
        public string name { get; set; }
        public double grade { get; set; }
        public char letterGrade { get; set; }
        public Student()
        {
             
        }
        public char GetLetterGrade()
        {
            if(this.grade >= 90)
            {
                return 'A';
            }
            else if(this.grade >= 80)
            {
                return 'B';
            }
            else if (this.grade >= 70)
            {
                return 'C';
            }
            else if (this.grade >= 60)
            {
                return 'D';
            }
            else { return 'F'; }
        }
        public override string ToString()
        {
            string newStr = $"{this.name} ({this.ID}), Grade: {this.grade} ({this.letterGrade})";
            return newStr;
        }
    }
}
