using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MissionStatistics.Domain
{
    public class Mission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Agent { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Country { get; set; } = null!;
        [Required]
        [StringLength(150)]
        public string Address { get; set; } = null!;
        public DateTime Date { get; set; }

    }
}