using Microsoft.EntityFrameworkCore;

namespace HaritaUygulamasi.Data
{
    public class AppDbContext :DbContext
    {
        protected readonly IConfiguration configuration;

        public AppDbContext(IConfiguration conf)
        {
            configuration = conf;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connect to postgresql with connection string from appsettings.json
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("CoordinateApp"));
        }

        public DbSet<Coordinate> Coordinates { get; set; }
    }
}
