using Domain.Contracts;
using Domain.Entities;
using Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Implementations;

public class GroupsRepository : IRepository<Group>
{
    private readonly DatabaseContext _context;

    public GroupsRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IQueryable<Group> Query => _context.Groups;

    public async Task<bool> Add(Group entity)
    {
        await _context.Groups.AddAsync(entity);
        return await SaveChanges();
    }

    public async Task<bool> Delete(long entityId)
    {
        var entity = await GetByID(entityId);
        if (entity == null)
        {
            return true;
        }
        _context.Groups.Remove(entity);
        return await SaveChanges();
    }

    public async Task<IEnumerable<Group>> GetAll()
    {
        return await _context.Groups.ToListAsync();
    }

    public async Task<Group> GetByID(long entityId)
    {
        return await _context.Groups.SingleAsync(x => x.Id == entityId);
    }

    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(Group entity)
    {
        _context.Groups.Update(entity);
        return await SaveChanges();
    }
}
