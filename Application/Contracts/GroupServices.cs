using Application.DTOs;

namespace Application.Contracts;

public interface IGroupServices
{
    Task<IEnumerable<GroupDTO>> GetGroups();
    Task<GroupDTO> GetGroupById(long groupId);
    Task<GroupDTO> CreateGroup(GroupDTO newGroup);
    Task<GroupDTO> UpdateGroup(GroupDTO updatedGroup);
    Task<bool> DeleteGroup(long groupId);
}
