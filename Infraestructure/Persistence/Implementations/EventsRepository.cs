using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Implementations;

public class EventsRepository : IRepository<Event>
{
    private readonly DatabaseContext _context;

    public HotelsRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IQueryable<Event> Query => _context.Events;

    public async Task<bool> Add(Event entity)
    {
        await _context.Hotels.AddAsync(entity);
        return await SaveChanges();
    }

    public async Task<bool> Delete(long entityId)
    {
        var entity = await GetByID(entityId);
        if (entity == null)
        {
            return true;
        }
        _context.Events.Remove(entity);
        return await SaveChanges();
    }

    public async Task<IEnumerable<Event>> GetAll()
    {
        return await _context.Events.ToListAsync();
    }

    public async Task<Event> GetByID(long entityId)
    {
        return await _context.Events.SingleAsync(x => x.Id == entityId);
    }

    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(Event entity)
    {
        _context.Events.Update(entity);
        return await SaveChanges();
    }
}
