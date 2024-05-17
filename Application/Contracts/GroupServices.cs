using Application.DTOs;

namespace Application.Contracts;

public interface IGroupServices
{
    IEnumerable<GroupDTO> GetGroups();
    GroupDTO GetGroupById(long groupId);
    GroupDTO CreateGroup(GroupDTO newGroup);
    GroupDTO UpdateGroup(GroupDTO updatedGroup);
    bool DeleteGroup(long groupId);
}
