namespace Mordor_Backend.Models.Dto
{
    public record GetOrkDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public OrkType Type { get; set; }
        public int NumberOfKills { get; set; }
        public List<string> Weapons { get; set; } = new();
    }
}