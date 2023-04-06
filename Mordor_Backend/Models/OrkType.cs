using System.Text.Json.Serialization;

namespace Mordor_Backend.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrkType
    {
        Mountain_ork,
        Black_ork,
        Uruk_Hai,
        Snaga_Slave
    }
}