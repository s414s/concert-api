using Application.DTOs;

namespace Application.Contracts;

public interface IGroupServices
{
    IEnumerable<GroupDTO> GetGroups();
    GroupDTO GetGroupById(long eventId);
    GroupDTO CreateGroup(GroupDTO newGroup);
    GroupDTO UpdateGroup(GroupDTO updatedGroup);
    bool DeleteGroup(long groupId);
}
