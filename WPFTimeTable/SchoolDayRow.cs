using System.Collections.Generic;

namespace WPFTimeTable
{
    public class SchoolDayRow
    {
        public List<SchoolDay> schoolDays { get; set; }
        public SchoolDayRow()
        {
            schoolDays = new List<SchoolDay>();
        }
    }
}
