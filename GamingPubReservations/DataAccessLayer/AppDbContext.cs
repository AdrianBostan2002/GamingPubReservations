using DataAccessLayer.Entities;
using DataAccessLayer.Enums;

namespace DataAccessLayer
{
    public static class AppDbContext
        {
            public static List<Customer> Customers = new List<Customer>
        {
            new Customer(1, "Sebi"),
            new Customer(2, "Adi"),
            new Customer(3, "Andrei"),
            new Customer(4, "Mircea"),
            new Customer(5, "Ionut"),
            new Customer(6, "Cristian"),
            new Customer(7, "George"),
            new Customer(8, "Adelin"),
            new Customer(9, "Marius"),
            new Customer(10, "Alex")
        };

            public static List<GamingPub> GamingPubs = new List<GamingPub>
        {
            new GamingPub()
            {
                Id= 1,
                Address="Street Iuliu Maniu 12B, Brasov",
                GamingPlatforms =
                {
                    new GamingPlatform(GamingPlatformType.Console, true),
                    new GamingPlatform(GamingPlatformType.Console, true),
                    new GamingPlatform(GamingPlatformType.Desktop, true),
                    new GamingPlatform(GamingPlatformType.Desktop, true),
                    new GamingPlatform(GamingPlatformType.Desktop, true),
                    new GamingPlatform(GamingPlatformType.Desktop, true),
                    new GamingPlatform(GamingPlatformType.Desktop, true),
                    new GamingPlatform(GamingPlatformType.Desktop, true),
                    new GamingPlatform(GamingPlatformType.VR, true),
                    new GamingPlatform(GamingPlatformType.VR, true),
                    new GamingPlatform(GamingPlatformType.VR, true),
                },
                Schedule = new GamingPubSchedule()
                {
                    Schedule = new Dictionary<DayOfWeek, Tuple<int, int>>()
                    {
                        { DayOfWeek.Monday, Tuple.Create(14, 23) },
                        { DayOfWeek.Tuesday, Tuple.Create(14, 23) },
                        { DayOfWeek.Wednesday, Tuple.Create(14, 23) },
                        { DayOfWeek.Thursday, Tuple.Create(14, 23) },
                        { DayOfWeek.Friday, Tuple.Create(14, 23) },
                        { DayOfWeek.Saturday, Tuple.Create(10, 23) },
                        { DayOfWeek.Sunday, Tuple.Create(0, 0) },
                    }
                },
                Reservations = new List<Reservation>()
                {
                    new Reservation(1, Customers[0], new DateTime(2023, 3, 25, 9, 15, 0), new DateTime(2023, 3, 25, 10, 15, 0), GamingPlatformType.Console),
                    new Reservation(2, Customers[1], new DateTime(2023, 3, 25, 10, 0, 0), new DateTime(2023, 3, 25, 11, 30, 0), GamingPlatformType.Desktop),
                    new Reservation(3, Customers[2], new DateTime(2023, 3, 25, 9, 15, 0), new DateTime(2023, 3, 25, 10, 15, 0), GamingPlatformType.VR),
                    new Reservation(4, Customers[1], new DateTime(2023, 3, 25, 11, 0, 0), new DateTime(2023, 3, 25, 12, 0, 0), GamingPlatformType.Desktop),
                    new Reservation(5, Customers[4], new DateTime(2023, 3, 26, 9, 15, 0), new DateTime(2023, 3, 26, 10, 15, 0), GamingPlatformType.Desktop),
                    new Reservation(6, Customers[2], new DateTime(2023, 3, 25, 13, 0, 0), new DateTime(2023, 3, 25, 14, 0, 0), GamingPlatformType.Desktop),
                    new Reservation(7, Customers[6], new DateTime(2023, 3, 25, 14, 0, 0), new DateTime(2023, 3, 25, 15, 0, 0), GamingPlatformType.Console)
                }
            }
        };

            public static List<Reservation> Reservations = new List<Reservation>(
                                                         from pub in GamingPubs
                                                         where pub != null
                                                         from reservation in pub.Reservations
                                                         select reservation);
        }
}