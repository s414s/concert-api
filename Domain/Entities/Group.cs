using Domain.Enum;

namespace Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool ExplicitContent { get; set; }
    public Genre Genre { get; set; }
}
