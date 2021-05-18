using System.Collections.Generic;
using Application.Dtos;
using Business.Entities;

namespace Application.Mappers
{
    public interface IMapper <Entity, Dto>
        where Entity : GenericEntity
        where Dto: GenericDto
    {
        Dto EntityToDto(Entity entity);

        IList<Dto> EntitiesToDto(IList<Entity> entities);

        Entity DtoToEntity(Dto entity);
    }
}
