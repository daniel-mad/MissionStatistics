﻿namespace MissionStatistics.Application.Models;
public partial class GeoApiResponse
{
    public class GeoDto
    {
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Country { get; set; }
        public string State { get; set; }

    }
}
