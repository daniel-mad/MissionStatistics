using MissionStatistics.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionStatistics.Application.Services
{
    public interface IMissionService
    {
        Task<List<MissionDto>> GetAllMissions();
        Task<MissionDto> GetMission(int id);
        Task<MissionDto> AddMission(CreateMissionDto mission);

        Task<(string?, int?)> GetMostIsolatedCountry();

        Task<MissionDto?> GetClosetMission(Location location);

    }
}
