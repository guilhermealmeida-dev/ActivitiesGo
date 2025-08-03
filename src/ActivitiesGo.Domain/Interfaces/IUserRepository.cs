using System;
using ActivitiesGo.Domain.Entities;
using ActivitiesGo.Domain.Interfaces.Base;

namespace ActivitiesGo.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    User? FindByEmail(string email);
    User? FindByCPF(string cpf);
}
