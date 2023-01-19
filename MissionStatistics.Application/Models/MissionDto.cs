using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionStatistics.Application.Models
{
    public class MissionDto
    {
        public int Id { get; set; }
        public string Agent { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime Date { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }

        public Geocoding? location { get; set; }
    }
}
