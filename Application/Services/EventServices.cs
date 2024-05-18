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

    public async Task<EventDTO> CreateEvent(EventDTO newEvent)
    {
        var isEntityCreated = await _eventsRepository.Add(EventDTO.MapToDomainEntity(newEvent));
        if (isEntityCreated)
            return newEvent;

        throw new ApplicationException("event could not be created");
    }

    public async Task<bool> DeleteEvent(long eventId)
    {
        var entity = await _eventsRepository.GetByID(eventId) ?? throw new ApplicationException("event not found");
        return await _eventsRepository.Delete(entity.Id);
    }

    public async Task<EventDTO> GetEventById(long eventId)
    {
        var entity = await _eventsRepository.GetByID(eventId) ?? throw new ApplicationException("event not found");
        return EventDTO.MapFromDomainEntity(entity);
    }

    public async Task<IEnumerable<EventDTO>> GetEvents()
    {
        var entities = await _eventsRepository.GetAll();
        return entities.Select(x => EventDTO.MapFromDomainEntity(x));
    }

    public async Task<EventDTO> UpdateEvent(long eventId, EventDTO newEventInfo)
    {
        if (await _eventsRepository.Update(EventDTO.MapToDomainEntity(newEventInfo)))
        {
            return newEventInfo;
        }
        else
        {
            throw new ApplicationException("entity could not be updated");
        }
    }
}
