using System;

namespace ActivitiesGo.Aplication.Interfaces.Base;

public interface IService<TRequestDto, TResponseDto> : IReadable<TResponseDto>, IWritable<TRequestDto, TRequestDto>
{

}
