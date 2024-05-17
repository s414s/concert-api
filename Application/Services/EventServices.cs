using Application.Contracts;
using Application.DTOs;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services;

public class EventServices : IEventServices
{
    private readonly IRepository<Event> _eventsRepository;

    public EventServices(IRepository<Event> eventsRepository)
    {
        _eventsRepository = eventsRepository;
    }

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

    public async Task<IEnumerable<EventDTO>> GetEvents()
    {
        var entities = await _eventsRepository.GetAll();
        return entities.Select(x => EventDTO.MapFromDomainEntity(x));
    }

    public EventDTO UpdateEvent(EventDTO newEventInfo)
    {
        throw new NotImplementedException();
    }

    public EventDTO UpdateEvent(long eventId, EventDTO newEventInfo)
    {
        throw new NotImplementedException();
    }
}
