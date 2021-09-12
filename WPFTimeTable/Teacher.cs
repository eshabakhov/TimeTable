using System.Collections.Generic;

namespace WPFTimeTable
{
    public class Teacher
    {
        public List<string> Subjects { get; set; }
        public string TeacherName { get; set; }
        public override string ToString()
        {
            return TeacherName;
        }
        public Teacher()
        {
            Subjects = new List<string>();
        }
    }
}
