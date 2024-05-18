using Domain.Entities;
using Domain.Enum;

namespace Application.DTOs;

public class NewGroupDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool ExplicitContent { get; set; }
    public Genre Genre { get; set; }

    public static NewGroupDTO MapFromDomainEntity(Group group)
    {
        return new NewGroupDTO
        {
            Id = group.Id,
            Name = group.Name,
            Password = group.Password,
            CreatedOn = group.CreatedOn,
            ExplicitContent = group.ExplicitContent,
            Genre = group.Genre,
        };
    }

    public static Group MapToDomainEntity(NewGroupDTO dto)
    {
        return new Group
        {
            Id = dto.Id,
            Name = dto.Name,
            Password = dto.Password,
            CreatedOn = dto.CreatedOn,
            ExplicitContent = dto.ExplicitContent,
            Genre = dto.Genre,
        };
    }
}
