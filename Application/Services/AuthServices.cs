using Application.Contracts;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services;

public class AuthServices : IAuthServices
{
    private readonly IRepository<Group> _groupsRepository;
    public AuthServices(IRepository<Group> groupsRepository)
    {
        _groupsRepository = groupsRepository;
    }

    public async Task<long> Login(string groupName, string password)
    {
        var groups = await _groupsRepository.GetAll();
        var group = groups?.FirstOrDefault(x => x.Name == groupName && x.Password == password);
        if (group != null)
            return group.Id;

        throw new ApplicationException("name or password incorrect");
    }
}
