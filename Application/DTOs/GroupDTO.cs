using Domain.Entities;
using Domain.Enum;

namespace Application.DTOs;

public class GroupDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool ExplicitContent { get; set; }
    public Genre Genre { get; set; }

    public static GroupDTO MapFromDomainEntity(Group group)
    {
        return new GroupDTO
        {
            Id = group.Id,
            Name = group.Name,
            CreatedOn = group.CreatedOn,
            ExplicitContent = group.ExplicitContent,
            Genre = group.Genre,
        };
    }

    public static Group MapToDomainEntity(GroupDTO groupDTO)
    {
        return new Group
        {
            Id = groupDTO.Id,
            Name = groupDTO.Name,
            CreatedOn = groupDTO.CreatedOn,
            ExplicitContent = groupDTO.ExplicitContent,
            Genre = groupDTO.Genre,
        };
    }
}
