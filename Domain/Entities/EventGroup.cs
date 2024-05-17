using Domain.Entities.Base;

namespace Domain.Entities;

public class EventGroup : Entity
{
    public long GroupId { get; set; }
    public long EventId { get; set; }
    public Group Group { get; set; }
    public Event Event { get; set; }
}
