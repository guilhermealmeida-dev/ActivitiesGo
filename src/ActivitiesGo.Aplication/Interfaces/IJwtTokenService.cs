using System;
using ActivitiesGo.Domain.Entities;

namespace ActivitiesGo.Aplication.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(User user);
    IDictionary<string, object> ValidateToken(string token);
}
