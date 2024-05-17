using Application.Contracts;
using Application.DTOs;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services;

public class GroupsServices : IGroupServices
{
    private readonly IRepository<Group> _grouposRepository;

    public GroupsServices(IRepository<Group> grouposRepository)
    {
        _grouposRepository = grouposRepository;
    }

    public GroupDTO CreateGroup(GroupDTO newGroup)
    {
        throw new NotImplementedException();
    }

    public bool DeleteGroup(long groupId)
    {
        throw new NotImplementedException();
    }

    public GroupDTO GetGroupById(long eventId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<GroupDTO>> GetGroups()
    {
        var groups = await _grouposRepository.GetAll();
        return groups.Select(x => GroupDTO.MapFromDomainEntity(x));
    }

    public GroupDTO UpdateGroup(GroupDTO updatedGroup)
    {
        throw new NotImplementedException();
    }
}
