using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTimeTable
{
    public class ScheduleRow
    {
        public List<StudentClass> studentClasses { get; set; }
        public ScheduleRow()
        {
            studentClasses = new List<StudentClass>();
        }
    }
}
