using System.Diagnostics.CodeAnalysis;

namespace BusinessLayer.Dtos
{
    public class AddDayScheduleDto
    {
        public DayOfWeek Day { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        [AllowNull]
        public DateTime? SpecialDate { get; set; } = null;
    }
}