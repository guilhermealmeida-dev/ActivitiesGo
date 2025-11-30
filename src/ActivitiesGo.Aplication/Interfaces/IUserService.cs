using System;
using ActivitiesGo.Aplication.Interfaces.Base;
using ActivitiesGo.Domain.Entities;

namespace ActivitiesGo.Aplication.Interfaces;

public interface IUserService
{
    Task<User> GetByIdAsync(Guid id);

}
