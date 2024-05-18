namespace Application.Contracts;

public interface IAuthServices
{
    Task<long> Login(string groupName, string password);
}
