using System;

namespace ActivitiesGo.Aplication.Interfaces.Base;

public interface IWritable<TRequestDto,TResponseDto>
{

    Task<TResponseDto> AddAsync(TRequestDto dto);
    Task<TResponseDto> UpdateAsync(TRequestDto dto);
    Task DeseteAsync(Guid Id);
}
