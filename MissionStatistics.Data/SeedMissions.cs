using Microsoft.EntityFrameworkCore;
using MissionStatistics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionStatistics.Data
{
    static class SeedMissions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mission>().HasData(
                new Mission 
                { 
                    Id = 1,
                    Agent = "007",
                    Country = "Brazil",
                    Address = "Avenida Vieira Souto 168 Ipanema, Rio de Janeiro",
                    Date = new DateTime(1995,12,17,21,45,17)
                }, 
                new Mission 
                {
                    Id = 2,
                    Agent = "005",
                    Country = "Poland",
                    Address = "Rynek Glowny 12, Krakow",
                    Date = new DateTime(2011,4,5,17,5,12)
                },
                new Mission 
                {
                    Id = 3,
                    Agent = "007",
                    Country = "Morocco",
                    Address = "27 Derb Lferrane, Marrakech",
                    Date = new DateTime(2001,1,1,12,0,0)
                },
                new Mission 
                {
                    Id = 4,
                    Agent = "005",
                    Country = "Brazil",
                    Address = "Rua Roberto Simonsen 122, Sao Paulo",
                    Date = new DateTime(1986,5,5,8,40,23)
                }, 
                new Mission 
                {
                    Id = 5,
                    Agent = "011",
                    Country = "Poland",
                    Address = "swietego Tomasza 35, Krakow",
                    Date = new DateTime(1997,9,7,19,12,53)
                },
                new Mission 
                {
                    Id = 6,
                    Agent = "003",
                    Country = "Morocco",
                    Address = "Rue Al-Aidi Ali Al-Maaroufi, Casablanca",
                    Date = new DateTime(2012,8,29,10,17,5)
                },
                new Mission 
                {
                    Id = 7,
                    Agent = "008",
                    Country = "Brazil",
                    Address = "Rua tamoana 418, tefe",
                    Date = new DateTime(2005,11,10,13,25,13)
                }, 
                new Mission 
                {
                    Id = 8,
                    Agent = "013",
                    Country = "Poland",
                    Address = "Zlota 9, Lublin",
                    Date = new DateTime(2002,10,17,10,52,19)
                }, 
                new Mission 
                {
                    Id = 9,
                    Agent = "002",
                    Country = "Morocco",
                    Address = "Riad Sultan 19, Tangier",
                    Date = new DateTime(2017,1,1,17,0,0)
                }, 
                new Mission 
                {
                    Id = 10,
                    Agent = "009",
                    Country = "Morocco",
                    Address = "atlas marina beach, agadir",
                    Date = new DateTime(2016,12,1,21,21,21)
                }
                );
        }
    }
}
