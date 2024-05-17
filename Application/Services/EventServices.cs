using Application.Contracts;
using Application.DTOs;

namespace Application.Services;

public class EventServices : IEventServices
{
    public EventDTO CreateEvent(EventDTO newEvent)
    {
        throw new NotImplementedException();
    }

    public bool DeleteEvent(long eventId)
    {
        throw new NotImplementedException();
    }

    public EventDTO GetEventById(long eventId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<EventDTO> GetEvents()
    {
        throw new NotImplementedException();
    }

    public EventDTO UpdateEvent(EventDTO newEventInfo)
    {
        throw new NotImplementedException();
    }
}
