using Microsoft.EntityFrameworkCore;
using OvStats_Website.DTO;

namespace OvStats_Website.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<SummonerAccountDTO> SummonerAccount { get; set; }
        public DbSet<SummonerStatsDTO> SummonerStats { get; set; }
        public DbSet<MatchDTO> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InfoDTO>()
                .HasMany(info => info.Participants)
                .WithOne()
                .HasForeignKey("InfoId");
        }
    }
}
