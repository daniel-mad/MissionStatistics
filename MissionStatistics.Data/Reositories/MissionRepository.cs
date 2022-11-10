using Microsoft.EntityFrameworkCore;
using MissionStatistics.Data.DbContexts;
using MissionStatistics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionStatistics.Data.Reositories
{
    public class MissionRepository : IMissionRepository
    {
        private readonly MissionStatisticsDbContext _context;

        public MissionRepository(MissionStatisticsDbContext context)
        {
            _context = context;
        }

        public async Task<Mission> AddMissionAsync(Mission mission)
        {
            await _context.Missions.AddAsync(mission);
            await _context.SaveChangesAsync();
            return mission;
        }

        public Task<List<Mission>> GetAllMissionsAsync()
        {
            return _context.Missions.ToListAsync();
        }

        public async Task<Mission?> GetMissionAsync(int id)
        {
            return await _context.Missions.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<(string?, int?)> GetMostIsolatedCountry()
        {
            //var isolatedAgentsQuery = _context.Missions.GroupBy(m => m.Agent).Where(g => g.Count() == 1).Select(g => g.Key);
            //var isolatedAgentsByCountryQuery = _context.Missions.GroupBy(m => m.Country).Select(g =>
            //new
            //{
            //    Name = g.Key,
            //    IsolatedAgents = g.Select(g => g.Agent).Where(a => isolatedAgentsQuery.Contains(a)).Count(),
                
            //});

            //var country = await isolatedAgentsByCountryQuery.SingleOrDefaultAsync(q => q.IsolatedAgents == isolatedAgentsByCountryQuery.Max(i => i.IsolatedAgents));

            var country = await _context.MaxIsolatedAgentsCountry.SingleOrDefaultAsync();
   
            return (country?.Name, country?.IsolatedAgentsCount);

        }
    }
}
