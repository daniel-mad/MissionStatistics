using MissionStatistics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionStatistics.Data.Reositories
{
    public interface IMissionRepository
    {
        Task<List<Mission>> GetAllMissionsAsync();
        Task<Mission?> GetMissionAsync(int id);

        Task<Mission> AddMissionAsync(Mission mission);

        Task<(string?, int?)> GetMostIsolatedCountry();
    }
}

