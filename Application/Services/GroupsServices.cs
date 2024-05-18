using Application.Contracts;
using Application.DTOs;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services;

public class GroupsServices : IGroupServices
{
    private readonly IRepository<Group> _groupsRepository;

    public GroupsServices(IRepository<Group> groupsRepository)
    {
        _groupsRepository = groupsRepository;
    }

    public async Task<GroupDTO> CreateGroup(GroupDTO newGroup)
    {
        var isEntityCreated = await _groupsRepository.Add(GroupDTO.MapToDomainEntity(newGroup));
        if (isEntityCreated)
            return newGroup;

        throw new ApplicationException("group could not be created");
    }

    public async Task<bool> DeleteGroup(long groupId)
    {
        var entity = await _groupsRepository.GetByID(groupId) ?? throw new ApplicationException("group not found");
        return await _groupsRepository.Delete(entity.Id);
    }

    public async Task<GroupDTO> GetGroupById(long eventId)
    {
        var entity = await _groupsRepository.GetByID(eventId) ?? throw new ApplicationException("group not found");
        return GroupDTO.MapFromDomainEntity(entity);
    }

    public async Task<IEnumerable<GroupDTO>> GetGroups()
    {
        var groups = await _groupsRepository.GetAll();
        return groups.Select(x => GroupDTO.MapFromDomainEntity(x));
    }

    public async Task<GroupDTO> UpdateGroup(GroupDTO updatedGroup)
    {
        if (await _groupsRepository.Update(GroupDTO.MapToDomainEntity(updatedGroup)))
        {
            return updatedGroup;
        }
        else
        {
            throw new ApplicationException("group could not be updated");
        }
    }
}
