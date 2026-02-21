using Microsoft.EntityFrameworkCore;

namespace Flight.Models
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions<FlightContext> options)
            : base(options)
        {
        }

        public DbSet<FlightModel> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightModel>().HasData(

                new FlightModel
                {
                    FlightNumber = "UA3321",
                    FromCity = "Chicago",
                    ToCity = "New York",
                    Date = new DateTime(2026, 2, 15),
                    Price = 235
                },

                new FlightModel
                {
                    FlightNumber = "QA1078",
                    FromCity = "Dubai",
                    ToCity = "London",
                    Date = new DateTime(2026, 3, 1),
                    Price = 590
                },

                new FlightModel
                {
                    FlightNumber = "CA9087",
                    FromCity = "Hong Kong",
                    ToCity = "San Francisco",
                    Date = new DateTime(2026, 6, 15),
                    Price = 900
                }
            );
        }
    }
}