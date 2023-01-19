using Microsoft.Extensions.Configuration;
using MissionStatistics.Application.Models;
using MissionStatistics.Domain.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static MissionStatistics.Application.Models.GeoApiResponse;

namespace MissionStatistics.Application.Services
{
    public class GeocodingService : IGeocodingService
    {

        private readonly string _apiKey;
        private readonly string _url;
        private readonly Dictionary<int, Geocoding> _missionsCoordinates = new();
        public HttpClient client { get; set; } = new HttpClient();

        public GeocodingService(IConfiguration configuration)
        {
            _apiKey = configuration["GeocodingApiSettings:ApiKey"];
            _url = configuration["GeocodingApiSettings:BaseUrl"];

        }

        public async Task<Geocoding?> GetGeocodingAsync(Location location)
        {
            // Check if Address or Coordinate
            var coordinateRegexPattern = @"^[-+]?([1-8]?\d(\.\d+)?|90(\.0+)?),\s*[-+]?(180(\.0+)?|((1[0-7]\d)|([1-9]?\d))(\.\d+)?)$";
            var rgx = new Regex(coordinateRegexPattern);
            if (rgx.IsMatch(location.TargetLocation))
            {
                return await GetCoordinateByCoordinate(location.TargetLocation);
            }
            var city = location.TargetLocation.Split(',', StringSplitOptions.RemoveEmptyEntries)[1];
            return await GetCoordinateByAddress(city);

        }

        private async Task<Geocoding?> GetCoordinateByCoordinate(string targetLocation)
        {
            var coordinate = targetLocation.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var lat = coordinate[0].Trim();
            var lon = coordinate[1].Trim();
            var url = $"{_url}reverse?lat={lat}&lon={lon}&limit=1&appid={_apiKey}";

            return await GetCoordinate(url);


        }


        private async Task<Geocoding?> GetCoordinateByAddress(string targetLocation)
        {
            var url = $"{_url}direct?q={targetLocation}&limit=1&appid={_apiKey}";
            return await GetCoordinate(url);
        }

        private async Task<Geocoding?> GetCoordinate(string url)
        {
            try
            {
                var response = await client.GetFromJsonAsync<IEnumerable<GeoDto>>(url);

                if (response is null || response.Count() == 0)
                {
                    throw new NotFoundException("Location not found.");
                }
                var geo = response.First();
                var geocoding = new Geocoding(geo.Lat, geo.Lon);
                return geocoding;
            }
            catch
            {

                throw;
            }

        }

        public async Task<Geocoding?> GetMissionGeocodingAsync(MissionDto mission)
        {
            Geocoding? coordinate;
            if (!_missionsCoordinates.TryGetValue(mission.Id, out coordinate))
            {
                var missionLocation = new Location
                {
                    TargetLocation = mission.Address
                };
                coordinate = await GetGeocodingAsync(missionLocation);

                if (coordinate == null)
                {
                    return null;
                }
                _missionsCoordinates.Add(mission.Id, coordinate);

            }
            return _missionsCoordinates[mission.Id];
        }
    }
}
