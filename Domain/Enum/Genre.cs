using System.Text.Json.Serialization;

namespace Domain.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Genre
{
    Rock = 1,
    Pop = 2,
    Rap = 3,
}
