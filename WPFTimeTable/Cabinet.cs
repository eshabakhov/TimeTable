namespace WPFTimeTable
{
    public class Cabinet
    {
        public string CabinetNumber { get; set; }
        public override string ToString()
        {
            return CabinetNumber;
        }
        //public List<int> Rooms { get; set; }
        //public Cabinet()
        //{
        //    Rooms = new List<int>();
        //}
    }
}
