using Domain.Entities;

namespace Application.DTOs;

public class EventDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string ZipCode { get; set; }
    public int Capacity { get; set; }
    public bool OnlyAdults { get; set; }
    public List<GroupDTO> Groups { get; set; } = [];

    public static EventDTO MapFromDomainEntity(Event e)
    {
        return new EventDTO
        {
            Id = e.Id,
            Name = e.Name,
            ZipCode = e.ZipCode,
            Capacity = e.Capacity,
            OnlyAdults = e.OnlyAdults,
            Groups = e.EventGroups.Select(x => GroupDTO.MapFromDomainEntity(x.Group)).ToList()
        };
    }

    public static Event MapToDomainEntity(EventDTO e)
    {
        return new Event
        {
            Id = e.Id,
            Name = e.Name,
            Capacity = e.Capacity,
            Date = e.Date,
            OnlyAdults = e.OnlyAdults,
            ZipCode = e.ZipCode,
        };
    }
}
