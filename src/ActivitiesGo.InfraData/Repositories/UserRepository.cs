using System;
using ActivitiesGo.Domain.Entities;
using ActivitiesGo.Domain.Interfaces;
using ActivitiesGo.InfraData.Context;
using ActivitiesGo.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ActivitiesGo.InfraData.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AplicationContext _context;
    public UserRepository(AplicationContext context)
    {
        _context = context;
    }
    public async Task<User> CreateAsync(User user)
    {
        var userDb = await _context.Users.AddAsync(user);
        _context.SaveChanges();
        return userDb.Entity;
    }

    public Task DeletAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> FindAllAsync()
    {
        throw new NotImplementedException();
    }

    public User? FindByCPF(string cpf)
    {
        var user = _context.Users.FirstOrDefault(user=>user.Email == cpf);
        return user;
    }

    public User? FindByEmail(string email)
    {
        var user = _context.Users.FirstOrDefault(user=>user.Email == email);
        return user;
    }

    public Task<User> FindByIdAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}
