namespace DataAccessLayer.Entities
{
    public class GamingPubSchedule
    {
        public Dictionary<DayOfWeek, Tuple<int, int>> Schedule { get; set; }

        public bool AddDaySchedule(DayOfWeek day, int startHour, int endHour)
        {
            //TODO: Check for valid start hour and end hour
            Tuple<int, int> hours = new Tuple<int, int>(startHour, endHour);
            Schedule.Add(day, hours);
            return true;
        }

        public bool CheckIfScheduleIsValid(DayOfWeek day, int startHour, int endHour)
        {
            //TODO:
            throw new NotImplementedException();
        }

        public bool EditDaySchedule(DayOfWeek day, int startHour, int endHour)
        {
            //TODO:
            throw new NotImplementedException();
        }

        public void PrintSchedule()
        {
            //TODO:
            throw new NotImplementedException();
        }
    }
}