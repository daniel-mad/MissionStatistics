using MissionStatistics.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionStatistics.Application.Services
{
    public interface IGeocodingService
    {
        Task<Geocoding?> GetGeocodingAsync(Location location);
        Task<Geocoding?> GetMissionGeocodingAsync(MissionDto mission);
    }
}
