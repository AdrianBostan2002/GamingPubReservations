using BusinessLayer.Dtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Mapping
{
    public static class ScheduleMappingExtensions
    {
        public static List<DaySchedule> ToDaySchedule(this AddScheduleDto addScheduleDto)
        {
            List<DaySchedule> daySchedules = new List<DaySchedule>();

            foreach (var daySchedule in addScheduleDto.Schedule)
            {
                daySchedules.Add
                (
                    new DaySchedule
                    {
                        Day = daySchedule.Day,
                        StartTime = daySchedule.StartTime,
                        EndTime = daySchedule.EndTime,
                        SpecialDate = daySchedule.SpecialDate,
                    }
                );
            }

            return daySchedules;
        }
    }
}