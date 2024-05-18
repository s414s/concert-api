using Domain.Entities.Base;

namespace Domain.Entities;

public class Event : Entity
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string ZipCode { get; set; }
    public int Capacity { get; set; }
    public bool OnlyAdults { get; set; }
    public ICollection<EventGroup> EventGroups { get; set; }
}
