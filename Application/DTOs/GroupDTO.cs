using Domain.Enum;

namespace Application.DTOs;

public class GroupDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool ExplicitContent { get; set; }
    public Genre Genre { get; set; }
}
