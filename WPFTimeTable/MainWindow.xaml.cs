using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private ObservableCollection<ScheduleRow> _scheduleRows;
        public ObservableCollection<ScheduleRow> ScheduleRows { get { return _scheduleRows; } set { _scheduleRows = value; OnPropertyChanged(nameof(ScheduleRows)); } }

        private ObservableCollection<Teacher> _teachers;
        public ObservableCollection<Teacher> Teachers { get { return _teachers; } set { _teachers = value; OnPropertyChanged(nameof(Teachers)); } }


        public MainWindow()
        {
            
            InitializeComponent();
            ScheduleRows = new ObservableCollection<ScheduleRow>();
            ScheduleRow scheduleRow = new ScheduleRow();

            Teachers = new ObservableCollection<Teacher>();
            Teacher teacher = new Teacher();

            scheduleRow.studentClasses.Add(new StudentClass { Name = "а", Subject = "b", Cabinet = 1 });
            scheduleRow.studentClasses.Add(new StudentClass { Name = "c", Subject = "d", Cabinet = 2 });
            scheduleRow.studentClasses.Add(new StudentClass { Name = "e", Subject = "f", Cabinet = 3 });

            teacher.TeacherName = "aboba";
            Teachers.Add(teacher);
            teacher.TeacherName = "abobus";
            Teachers.Add(teacher);
            teacher.TeacherName = "abobuus";
            Teachers.Add(teacher);

            ScheduleRows.Add(scheduleRow);

            DataContext = this;
        }
    }
}
