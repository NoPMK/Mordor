using System.ComponentModel.DataAnnotations;

namespace Mordor_Backend.Models.Dto
{
    public record CreateOrkDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EnumDataType(typeof(OrkType), ErrorMessage = "Not valid Ork type.")]
        public OrkType Type { get; set; }
        public int NumberOfKills { get; set; }
        public List<string> Weapons { get; set; } = new();
    }
}