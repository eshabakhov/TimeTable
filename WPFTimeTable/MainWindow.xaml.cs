using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace WPFTimeTable
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private ObservableCollection<Teacher> teachers;
        public ObservableCollection<Teacher> Teachers
        {
            get => teachers;
            set
            {
                teachers = value;
                OnPropertyChanged(nameof(Teachers));
            }
        }
        private ObservableCollection<Cabinet> cabinets;
        public ObservableCollection<Cabinet> Cabinets
        {
            get => cabinets;
            set
            {
                cabinets = value;
                OnPropertyChanged(nameof(Cabinets));
            }
        }
        private ObservableCollection<List<SchoolDay>> schoolDayRow;
        public ObservableCollection<List<SchoolDay>> SchoolDayRows
        {
            get
            {
                return schoolDayRow;
            }
            set
            {
                schoolDayRow = value;
                OnPropertyChanged(nameof(SchoolDayRow));
            }
        }
        public DataTable Schedule { get; set; }
        public MainWindow()
        {
            InitializeComponent();

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
            Schedule.Rows[0]["5А"] = new SchoolDay { Teacher = Teachers[0], Cabinet = Cabinets[0], Subject = "z" };
            Schedule.Rows[0]["5Б"] = new SchoolDay { Teacher = Teachers[0], Cabinet = Cabinets[0], Subject = "z" };

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

            DataContext = this;
        }

        private void ScheduleDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(SchoolDay))
            {
                e.Column = new DataGridTemplateColumn()
                {
                    CellTemplate = (DataTemplate)Resources["TeacherComboBox"]
                };
            }
        }
    }
}
