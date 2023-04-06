using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mordor_Backend.Models
{
    public class Ork
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]      
        public OrkType Type { get; set; }
        public int NumberOfKills { get; set; }
        public List<Weapon> Weapons { get; set; } = new();
    }
}
