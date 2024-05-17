using Application.DTOs;

namespace Application.Contracts;

public interface IEventServices
{
    IEnumerable<EventDTO> GetEvents();
    EventDTO GetEventById(long eventId);
    EventDTO CreateEvent(EventDTO newEvent);
    EventDTO UpdateEvent(int eventId, EventDTO newEventInfo);
    bool DeleteEvent(long eventId);
}
