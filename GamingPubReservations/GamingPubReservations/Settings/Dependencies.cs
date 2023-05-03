using BusinessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Repositories;

namespace GamingPubReservations.Settings
{
    public static class Dependencies
    {

        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();

            applicationBuilder.Services.AddDbContext<AppDbContext>();

            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<CustomerService>();
            services.AddScoped<ReservationService>();
            services.AddScoped<GamingPubService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<CustomersRepository>();
            services.AddScoped<GamingPubsRepository>();
            services.AddScoped<ReservationsRepository>();
            services.AddScoped<UnitOfWork>();
        }
    }
}