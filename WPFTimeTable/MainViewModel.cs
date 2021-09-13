using Simplified;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace WPFTimeTable
{
    public class MainViewModel : BaseInpc
    {
        private DataTable _schedule;

        public ObservableCollection<Teacher> Teachers { get; } = new ObservableCollection<Teacher>();
        public ObservableCollection<Cabinet> Cabinets { get; } = new ObservableCollection<Cabinet>();
        public ObservableCollection<List<SchoolDay>> SchoolDayRows { get; } = new ObservableCollection<List<SchoolDay>>();
        public DataTable Schedule { get => _schedule; set => Set(ref _schedule, value); }
        public MainViewModel()
        {
            Cabinets = new ObservableCollection<Cabinet>();
            Cabinet cabinet;

            Teachers = new ObservableCollection<Teacher>();
            Teacher teacher;

            for (int i = 0; i < 15; i++)
            {
                teacher = new Teacher();
                teacher.TeacherName = (i + 1).ToString() + " учитель";
                Teachers.Add(teacher);
                Teachers[i].Subjects.Add("Алгебра");
                Teachers[i].Subjects.Add("Геометрия");

                cabinet = new Cabinet();
                cabinet.CabinetNumber = (i + 1).ToString();
                Cabinets.Add(cabinet);
            }
            Teachers[1].Subjects.Add("Русский");

            Schedule = new DataTable();
            Schedule.Rows.Add(Schedule.NewRow());
            Schedule.Columns.Add(new DataColumn("5А", typeof(SchoolDay)));
            Schedule.Columns.Add(new DataColumn("5Б", typeof(SchoolDay)));
            Schedule.Rows[0]["5А"] = new SchoolDay { Teacher = Teachers[0], Cabinet = Cabinets[0], Subject = Teachers[0].Subjects[0] };
            Schedule.Rows[0]["5Б"] = new SchoolDay { Teacher = Teachers[0], Cabinet = Cabinets[0], Subject = Teachers[0].Subjects[1] };
            Schedule.Rows.Add(Schedule.NewRow());
            Schedule.Rows[1]["5А"] = new SchoolDay { Teacher = Teachers[1], Cabinet = Cabinets[1], Subject = Teachers[1].Subjects[0] };
            Schedule.Rows[1]["5Б"] = new SchoolDay { Teacher = Teachers[1], Cabinet = Cabinets[1], Subject = Teachers[1].Subjects[1] };

            SchoolDayRows = new ObservableCollection<List<SchoolDay>>();
            SchoolDayRows.Add(new List<SchoolDay>());
            SchoolDayRows.Add(new List<SchoolDay>());

            SchoolDayRows[0].Add(new SchoolDay { Teacher = Teachers[0], Cabinet = Cabinets[0], Subject = "z" });
            SchoolDayRows[1].Add(new SchoolDay { Teacher = Teachers[1], Cabinet = Cabinets[1], Subject = "z" });
            SchoolDayRows[0].Add(new SchoolDay { Teacher = Teachers[2], Cabinet = Cabinets[2], Subject = "z" });

            //SchoolDayRow schoolDayRow = new SchoolDayRow();
            //ComboBox TeacherComboBox = new ComboBox();
            //schoolDayRow.schoolDays.Add(new SchoolDay { Teacher = Teachers[0], Subject = "b", Cabinet = Cabinets[0] });
            //TeacherComboBox.ItemsSource = schoolDayRow.schoolDays;

        }

    }
}
