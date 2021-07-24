using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTimeTable
{
    public class Teacher
    {
        public string TeacherName { get; set; }

        public override string ToString()
        {
            return TeacherName;
        }
    }
}
