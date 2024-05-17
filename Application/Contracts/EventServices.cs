using Application.DTOs;

namespace Application.Contracts;

public interface IEventServices
{
    Task<IEnumerable<EventDTO>> GetEvents();
    EventDTO GetEventById(long eventId);
    EventDTO CreateEvent(EventDTO newEvent);
    EventDTO UpdateEvent(long eventId, EventDTO newEventInfo);
    bool DeleteEvent(long eventId);
}
