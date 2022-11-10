using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionStatistics.Domain.Models
{
    public class MaxIsolatedAgentsCountryView
    {
        [Column("country")]
        public string Name { get; set; } = string.Empty;
        [Column("isolated_agents")]
        public int IsolatedAgentsCount { get; set; }
    }
}
