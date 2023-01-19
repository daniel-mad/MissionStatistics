using AutoMapper;
using MissionStatistics.Application.Models;
using MissionStatistics.Data.Reositories;
using MissionStatistics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionStatistics.Application.Services
{
    public class MissionService : IMissionService
    {
        private readonly IMissionRepository _repository;
        private readonly IMapper _mapper;
        private readonly IGeocodingService _geocodingService;


        public MissionService(IMissionRepository repository, IMapper mapper, IGeocodingService geocodingService)
        {
            _repository = repository;
            _mapper = mapper;
            _geocodingService = geocodingService;

        }

        public async Task<MissionDto> AddMission(CreateMissionDto mission)
        {
            var missionDb = _mapper.Map<Mission>(mission);
            await _repository.AddMissionAsync(missionDb);
            return _mapper.Map<MissionDto>(missionDb);
        }

        public async Task<List<MissionDto>> GetAllMissions()
        {
            var missions = await _repository.GetAllMissionsAsync();
            return _mapper.Map<List<MissionDto>>(missions);
        }

        public async Task<MissionDto?> GetClosetMission(Location location)
        {
            var geoCoding = await _geocodingService.GetGeocodingAsync(location);
            if (geoCoding == null)
            {
                return null;
            }
            var missions = await GetAllMissions();

            var closetMission = await FindCloset(missions, geoCoding);
            return closetMission;

        }

        private async Task<MissionDto> FindCloset(List<MissionDto> missions, Geocoding? geoCoding)
        {
            MissionDto closet = missions[0];
            int maxDistance = int.MaxValue;
            foreach (var mission in missions)
            {
                if (mission.Address.Split(',', StringSplitOptions.RemoveEmptyEntries).Length < 2)
                {
                    continue;
                }
                var coordinate = await _geocodingService.GetMissionGeocodingAsync(mission);
                if (coordinate == null)
                {
                    continue;
                }


                mission.location = coordinate;

                int distance = GetDistance(coordinate!, geoCoding!);
                if (distance < maxDistance)
                {
                    maxDistance = distance;
                    closet = mission;
                }
            }

            return closet;
        }

        private int GetDistance(Geocoding coordinate, Geocoding geoCoding)
        {
            var x = Math.Pow((geoCoding.Latitude - coordinate.Latitude), 2);
            var y = Math.Pow((geoCoding.Longitude - coordinate.Longitude), 2);
            var distance = Math.Sqrt(x + y);

            return (int)distance;
        }

        public async Task<MissionDto> GetMission(int id)
        {
            var mission = await _repository.GetMissionAsync(id);
            return _mapper.Map<MissionDto>(mission);
        }

        public async Task<(string?, int?)> GetMostIsolatedCountry()
        {
            return await _repository.GetMostIsolatedCountry();
        }
    }
}
