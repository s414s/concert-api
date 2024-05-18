using Application.DTOs;

namespace Application.Contracts;

public interface IEventServices
{
    Task<IEnumerable<EventDTO>> GetEvents();
    Task<EventDTO> GetEventById(long eventId);
    Task<EventDTO> CreateEvent(EventDTO newEvent);
    Task<EventDTO> UpdateEvent(long eventId, EventDTO newEventInfo);
    Task<bool> DeleteEvent(long eventId);
}
