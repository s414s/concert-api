namespace Application.Contracts;

public interface IAuthServices
{
    Task<bool> Login(string groupName, string password);
}
