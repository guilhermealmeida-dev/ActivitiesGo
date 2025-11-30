using ActivitiesGo.Aplication.Interfaces;
using ActivitiesGo.Domain.Entities;
using ActivitiesGo.Domain.Interfaces;

namespace ActivitiesGo.Aplication.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        return user;
    }
}
