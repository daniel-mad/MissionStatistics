using Microsoft.Extensions.Configuration;
using MissionStatistics.Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (location.TargetLocation.Split(',').Length != 2)
                return await GetCoordinateByAddress(location.TargetLocation);

            return await GetCoordinateByCoordinate(location.TargetLocation);

        }

        private async Task<Geocoding?> GetCoordinateByCoordinate(string targetLocation)
        {
            var url = $"{_url}reverse?access_key={_apiKey}&query={targetLocation}";
            if (!ValidateCoordinate(targetLocation))
            {
                return null;
            }
            return await GetCoordinate(url);
            

        }

        private bool ValidateCoordinate(string targetLocation)
        {
            var coordinates = targetLocation.Split(',');
            foreach (var c in coordinates)
            {
                if (!Double.TryParse(c, out double _))
                    return false;
            }

            return true;
        }

        private async Task<Geocoding?> GetCoordinateByAddress(string targetLocation)
        {
            var url = $"{_url}forward?access_key={_apiKey}&query={targetLocation}";
            return await GetCoordinate(url);
        }

        private async Task<Geocoding?> GetCoordinate(string url)
        {
            
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                //var json = await response.Content.ReadAsAsync<GeoResponse>();
                
                var json =  response.Content.ReadAsStringAsync().Result;
                if (string.IsNullOrEmpty(json))
                {
                    return null;
                }
                try
                {
                    var data = JsonConvert.DeserializeObject<GeoResponse>(json)!;
                    
                   
                    var geo = data?.Data?[0]!;
                   
                    var geocoding = new Geocoding(geo.Latitude, geo.Longitude);
                    return geocoding;

                }
                catch 
                {

                    return null;
                }
                
            }
            throw new Exception(response.ReasonPhrase);
        }

        public async Task<Geocoding?> GetMissionGeocodingAsync(MissionDto mission)
        {
            Geocoding? coordinate;
            if (!_missionsCoordinates.TryGetValue(mission.Id, out coordinate))
            {
                var missionLocation = new Location
                {
                    TargetLocation = mission.Address.Split(',')[0]
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
