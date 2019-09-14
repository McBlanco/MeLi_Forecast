using MeLi_Forecast.Entities.Forecasting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MeLi_Forecast.App.Database
{
    public class ForecastDbContext : DbContext
    {
        public DbSet<ForecastDay> ForecastDays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MeLi_Forecast.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<ForecastDay>().ToTable("ForecastDays");
            modelBuilder.Entity<ForecastDay>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Day).IsUnique();
                entity.HasIndex(e => e.Date).IsUnique();
            });


            base.OnModelCreating(modelBuilder);
        }
    }


}
