using System;

namespace ActivitiesGo.Aplication.Interfaces.Base;

public interface IReadable<TResponseDto>
{
    Task<IEnumerable<TResponseDto>> GetAllAsync();
    Task<TResponseDto> GetByIdAsync(Guid id);
}
