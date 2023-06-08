using DataAccessLayer.Entities;

namespace BusinessLayer.Dtos
{
    public class AddScheduleDto
    {
        public int GamingPubId { get; set; }

        public List<AddDayScheduleDto> Schedule { get; set; }
    }
}