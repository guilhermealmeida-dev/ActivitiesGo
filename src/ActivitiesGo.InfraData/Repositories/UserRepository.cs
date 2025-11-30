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

    public Task<User?> FindByCPFAsync(string cpf)
    {
        return (from user in _context.Users
                where user.CPF == cpf
                select user).FirstOrDefaultAsync();
    }

    public Task<User?> FindByEmailAsync(string email)
    {
        return (from user in _context.Users
                where user.Email == email
                select user).FirstOrDefaultAsync();
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
