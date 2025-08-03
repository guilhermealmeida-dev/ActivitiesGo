using System;
using ActivitiesGo.Domain.Entities.Base;

namespace ActivitiesGo.Domain.Interfaces.Base;

public interface IRepository<TEntity> where TEntity : IEntityBase
{
    Task<IEnumerable<TEntity>> FindAllAsync();
    Task<TEntity> FindByIdAsync(Guid Id);
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task DeletAsync(Guid Id);
}
