using System;
using ActivitiesGo.Domain.Entities;
using ActivitiesGo.Domain.Interfaces.Base;

namespace ActivitiesGo.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> FindByEmailAsync(string email);
    Task<User?> FindByCPFAsync(string cpf);
}
