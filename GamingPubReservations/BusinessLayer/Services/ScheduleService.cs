using BusinessLayer.Dtos;
using BusinessLayer.Infos;
using BusinessLayer.Mapping;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BusinessLayer.Services
{
    public class ScheduleService
    {
        private const string CLOSED_SCHEDULE = "Closed";

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

            List<DaySchedule> schedule = addScheduleDto.ToSchedule();

            if (!CheckIfScheduleHasValidStartTimeAndEndTime(schedule))
            {
                return false;
            }

            SetGamingPubForEveryDayInSchedule(schedule, foundGamingPub);

            foreach (DaySchedule day in schedule)
            {
                unitOfWork.Schedule.Insert(day);
            }

            unitOfWork.SaveChanges();

            return true;
        }

        public bool AddSameScheduleForDifferentGamingPub(int sourceGamingPubId, int destinationGamingPubId)
        {
            var sourceGamingPub = unitOfWork.GamingPubs.GetById(sourceGamingPubId);
            var destinationGamingPub = unitOfWork.GamingPubs.GetById(destinationGamingPubId);

            if (sourceGamingPub == null || destinationGamingPub == null)
            {
                return false;
            }

            sourceGamingPub.Schedule = unitOfWork.Schedule.GetByGamingPubId(sourceGamingPubId);

            if (sourceGamingPub.Schedule.Count == 0)
            {
                return false;
            }

            destinationGamingPub.Schedule = new List<DaySchedule>(sourceGamingPub.Schedule);

            unitOfWork.SaveChanges();

            return true;
        }

        public bool UpdateDaySchedule(AddOrUpdateDayScheduleDto updateDayDto, int gamingPubId)
        {
            var foundGamingPub = unitOfWork.GamingPubs.GetById(gamingPubId);

            if (foundGamingPub == null)
            {
                return false;
            }

            foundGamingPub.Schedule = unitOfWork.Schedule.GetByGamingPubId(gamingPubId);

            DaySchedule updatedDay = updateDayDto.ToDaySchedule();

            if (!CheckIfStartTimeAndEndTimeAreValid(updatedDay.StartTime, updatedDay.EndTime))
            {
                return false;
            }

            DaySchedule foundDay = foundGamingPub.Schedule.Where(d => d.Day == updatedDay.Day).FirstOrDefault();

            if (foundDay == null)
            {
                if (foundGamingPub.Schedule == null)
                {
                    foundGamingPub.Schedule = new List<DaySchedule>();
                }

                foundGamingPub.Schedule.Add(updatedDay);
            }
            else
            {
                foundDay.Day = updatedDay.Day;
                foundDay.StartTime = updatedDay.StartTime;
                foundDay.EndTime = updatedDay.EndTime;
                foundDay.SpecialDate = updatedDay.SpecialDate;
            }

            unitOfWork.SaveChanges();

            return true;
        }

        public bool DeleteSchedule(int gamingPubId)
        {
            var foundGamingPub = unitOfWork.GamingPubs.GetById(gamingPubId);

            if (foundGamingPub == null)
            {
                return false;
            }

            foundGamingPub.Schedule = unitOfWork.Schedule.GetByGamingPubId(gamingPubId);

            if (foundGamingPub.Schedule.Count == 0)
            {
                return false;
            }

            foundGamingPub.Schedule.Clear();

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

        public List<DayScheduleInfo> GetSchedule(int gamingPubId)
        {
            GamingPub foundGamingPub = unitOfWork.GamingPubs.GetById(gamingPubId);

            List<DayScheduleInfo> schedule = new List<DayScheduleInfo>();

            if(foundGamingPub== null)
            {
                return schedule;
            }

            foundGamingPub.Schedule = unitOfWork.Schedule.GetByGamingPubId(gamingPubId);

            foreach (var day in foundGamingPub.Schedule)
            {
                schedule.Add(day.ToDayScheduleInfo());
            }

            return schedule;

        }
      
        private bool CheckIfScheduleHasValidStartTimeAndEndTime(List<DaySchedule> schedule)
        {
            foreach (var day in schedule)
            {
                if (!CheckIfStartTimeAndEndTimeAreValid(day.StartTime, day.EndTime))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckIfStartTimeAndEndTimeAreValid(string startTime, string endTime)
        {
            if
            (
               TimeSpan.TryParse(startTime, out _) && TimeSpan.TryParse(endTime, out _) ||
               startTime.Equals(CLOSED_SCHEDULE, StringComparison.InvariantCultureIgnoreCase) && endTime.Equals(CLOSED_SCHEDULE, StringComparison.InvariantCultureIgnoreCase)
            )
            {
                return true;
            }

            return false;
        }
    }
}