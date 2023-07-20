using Microsoft.EntityFrameworkCore;
using NET106_Demo_Shared;
using System.Reflection;

namespace NET106_Demo_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<FootballPlayer> FootballPlayers { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Positions Table
            modelBuilder.Entity<Position>().HasData(
                new Position { PositionId = 1, PosiotionName = "FW" });
            modelBuilder.Entity<Position>().HasData(
                new Position { PositionId = 2, PosiotionName = "MF" });
            modelBuilder.Entity<Position>().HasData(
                new Position { PositionId = 3, PosiotionName = "DF" });
            modelBuilder.Entity<Position>().HasData(
                new Position { PositionId = 4, PosiotionName = "GK" });

            // Seed FootballPlayers Table
            modelBuilder.Entity<FootballPlayer>().HasData(new FootballPlayer
            {
                FootballPlayerId = 1,
                FullName = "Nguyen Quang Huy",
                Nationality = "Vietnam",
                DateOfBirth = new DateTime(2023, 01, 01),
                PositionId = 1,
                Photo = "images/nophoto.png"
            });
        }
    }
}
