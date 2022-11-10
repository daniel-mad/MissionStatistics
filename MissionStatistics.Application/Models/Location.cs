using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MissionStatistics.Application.Models
{
    public class Location
    {
        [JsonPropertyName("target-location")]
        public string TargetLocation { get; set; } = null!;
    }
}
