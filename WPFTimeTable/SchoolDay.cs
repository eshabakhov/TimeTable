using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFTimeTable
{
    public class SchoolDay : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private Teacher _teacher;
        public Teacher Teacher
        {
            get => _teacher;
            set
            {
                _teacher = value;
                OnPropertyChanged(nameof(Teacher));
            }
        }
        private Cabinet _cabinet;
        public Cabinet Cabinet
        {
            get => _cabinet;
            set
            {
                _cabinet = value;
                OnPropertyChanged(nameof(Cabinet));
            }
        }
        public string Subject { get; set; }
    }
}
