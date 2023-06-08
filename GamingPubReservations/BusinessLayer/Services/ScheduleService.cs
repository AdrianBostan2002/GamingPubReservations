using BusinessLayer.Dtos;
using BusinessLayer.Mapping;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BusinessLayer.Services
{
    public class ScheduleService
    {
        private readonly UnitOfWork unitOfWork;

        public ScheduleService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool AddSchedule(AddScheduleDto addScheduleDto)
        {
            var foundGamingPub = unitOfWork.GamingPubs.GetById(addScheduleDto.GamingPubId);

            if (foundGamingPub == null)
            {
                return false;
            }

            var foundSchedule = unitOfWork.Schedule.GetByGamingPubId(foundGamingPub.Id);

            if (foundSchedule.Count != 0)
            {
                return false;
            }

            List<DaySchedule> schedule = addScheduleDto.ToDaySchedule();

            SetGamingPubForEveryDayInSchedule(schedule, foundGamingPub);

            foreach (DaySchedule day in schedule)
            {
                unitOfWork.Schedule.Insert(day);
            }

            unitOfWork.SaveChanges();

            return true;
        }

        private void SetGamingPubForEveryDayInSchedule(List<DaySchedule> schedule, GamingPub gamingPub)
        {
            foreach (var day in schedule)
            {
                if (day.GamingPubs == null)
                    day.GamingPubs = new List<GamingPub>();

                day.GamingPubs.Add(gamingPub);
            }
        }
    }
}