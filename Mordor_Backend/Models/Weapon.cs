using System.ComponentModel.DataAnnotations;

namespace Mordor_Backend.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int OrkId { get; set; }
        public Ork? Ork { get; set; }
    }
}
