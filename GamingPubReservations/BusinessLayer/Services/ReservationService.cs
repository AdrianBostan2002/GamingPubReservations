using BusinessLayer.Dtos;
using BusinessLayer.Mapping;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BusinessLayer.Services
{
    public class ReservationService
    {
        private readonly UnitOfWork unitOfWork;

        public ReservationService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool AddReservation(AddOrUpdateReservationDto addReservationDto)
        {
            var foundGamingPub = unitOfWork.GamingPubs.GetById(addReservationDto.GamingPubId);

            if (foundGamingPub == null)
            {
                return false;
            }

            var foundGamingPlatform = unitOfWork.GamingPlatforms.GetById(addReservationDto.GamingPlatformId);

            if (foundGamingPlatform == null)
            {
                return false;
            }

            Reservation reservation = addReservationDto.ToReservation();

            reservation.GamingPub = foundGamingPub;
            reservation.GamingPlatform = foundGamingPlatform;

            unitOfWork.Reservations.Insert(reservation);

            unitOfWork.SaveChanges();

            return true;
        }

        public bool UpdateReservation(AddOrUpdateReservationDto updateReservationDto, int reservationId)
        {
            Reservation foundReservation = unitOfWork.Reservations.GetById(reservationId);

            if (foundReservation == null)
            {
                return false;
            }

            var foundGamingPub = unitOfWork.GamingPubs.GetById(updateReservationDto.GamingPubId);
            var foundGamingPlatform = unitOfWork.GamingPlatforms.GetById(updateReservationDto.GamingPlatformId);

            if (foundGamingPub == null || foundGamingPlatform == null)
            {
                return false;
            }

            Reservation updatedReservation = updateReservationDto.ToReservation();

            updatedReservation.Copy(foundReservation);

            foundReservation.GamingPub = foundGamingPub;
            foundReservation.GamingPlatform = foundGamingPlatform;

            unitOfWork.SaveChanges();

            return true;
        }

        public bool DeleteReservation(int reservationId)
        {
            var foundReservation = unitOfWork.Reservations.GetById(reservationId);

            if (foundReservation == null)
            {
                return false;
            }

            unitOfWork.Reservations.Remove(foundReservation);

            unitOfWork.SaveChanges();

            return true;
        }

        public List<AvailableReservation> GetByDate(DateTime date, int gamingPubId)
        {
            var foundGamingPub = unitOfWork.GamingPubs.GetById(gamingPubId);

            foundGamingPub.Schedule = unitOfWork.Schedule.GetByGamingPubId(gamingPubId);

            foundGamingPub.GamingPlatforms = unitOfWork.GamingPlatforms.GetByGamingPub(foundGamingPub);

            foundGamingPub.Reservations = unitOfWork.Reservations.GetAllReservationsFromSpecificDate(date, foundGamingPub);

            if (foundGamingPub == null || foundGamingPub.Schedule == null || foundGamingPub.GamingPlatforms.Count == 0)
            {
                return null;
            }

            return GetAvailableReservationFromSpecificDay(date, foundGamingPub);
        }

        public List<Reservation> GetAll()
        {
            return unitOfWork.Reservations.GetAll();
        }


        private List<AvailableReservation> GetAvailableReservationFromSpecificDay(DateTime specificDay, GamingPub gamingPub)
        {
            var day = gamingPub.Schedule.Where(x => x.Day == specificDay.DayOfWeek).FirstOrDefault();

            if (day.StartTime == "Closed") return null;

            int startHour, endHour;
            GetStartHourAndEndHour(day, out startHour, out endHour);

            List<AvailableReservation> allAvailablesReservations = new List<AvailableReservation>();

            while (startHour != endHour)
            {
                List<Reservation> unAvailableReservations = gamingPub.Reservations.Where(x => x.StartDate.Hour == startHour).ToList();

                if (unAvailableReservations.Count == 0)
                {
                    AvailableReservation availableReservation = CreateNewAvailableReservation(startHour, specificDay, gamingPub.Name, gamingPub.GamingPlatforms.ToList());

                    allAvailablesReservations.Add(availableReservation);
                }
                else
                {
                    Dictionary<GamingPlatform, int> unAvailablePlatforms = GetUnavailablePlatformsAndTheirNumber(unAvailableReservations);

                    AvailableReservation availableReservation = CreateNewAvailableReservation(startHour, specificDay, gamingPub.Name, null);

                    foreach (GamingPlatform gamingPlatform in gamingPub.GamingPlatforms)
                    {
                        if (!unAvailablePlatforms.ContainsKey(gamingPlatform))
                        {
                            availableReservation.AvailableGamingPlatformsName.Add(gamingPlatform.Name);
                        }
                    }

                    if (availableReservation.AvailableGamingPlatformsName.Count != 0)
                    {
                        allAvailablesReservations.Add(availableReservation);
                    }
                }

                startHour++;
            }

            return allAvailablesReservations;
        }

        private void GetStartHourAndEndHour(DaySchedule? day, out int startHour, out int endHour)
        {
            startHour = int.Parse(day.StartTime.Substring(0, 2));
            endHour = int.Parse(day.EndTime.Substring(0, 2));
        }

        private Dictionary<GamingPlatform, int> GetUnavailablePlatformsAndTheirNumber(List<Reservation> unAvailableReservations)
        {
            return (from reservation in unAvailableReservations
                    group reservation by reservation.GamingPlatform into g
                    select new { GamingPlatform = g.Key, Count = g.Count() })
                                            .ToDictionary(item => item.GamingPlatform, item => item.Count);
        }

        private AvailableReservation CreateNewAvailableReservation(int startHour, DateTime specificDay, string name, List<GamingPlatform> gamingPlatforms)
        {
            DateTime availableStartDate = new DateTime(specificDay.Year, specificDay.Month, specificDay.Day, startHour, 0, 0);
            DateTime availableEndDate = new DateTime(specificDay.Year, specificDay.Month, specificDay.Day, startHour + 1, 0, 0);

            AvailableReservation availableReservation = new AvailableReservation
            {
                StartDate = availableStartDate,
                EndDate = availableEndDate,
                GamingPubName = name,
                AvailableGamingPlatformsName = gamingPlatforms?.Select(p => p.Name).ToList() ?? new List<string>()
            };

            return availableReservation;
        }
    }
}