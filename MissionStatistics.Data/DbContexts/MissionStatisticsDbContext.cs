using Microsoft.EntityFrameworkCore;
using MissionStatistics.Domain;
using MissionStatistics.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionStatistics.Data.DbContexts
{
    public class MissionStatisticsDbContext : DbContext
    {
        public MissionStatisticsDbContext(DbContextOptions<MissionStatisticsDbContext> options)
            : base(options)
        {

        }

        public DbSet<Mission> Missions { get; set; }
        public DbSet<MaxIsolatedAgentsCountryView> MaxIsolatedAgentsCountry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Seed();
            modelBuilder.Entity<MaxIsolatedAgentsCountryView>().HasNoKey().ToView("vMaxIsolatedAgentsInCountry");
        }
    }
}
