using System.Collections.Generic;
using Application.Dtos;
using Application.Factories.Dtos;
using Application.Mappers.Interfaces;
using Business.Entities;
using Business.Factories.Entities;

namespace Application.Mappers.Implementations
{
    public class MunicipioMapper : IMunicipioMapper
    {
        
        public MunicipioDto EntityToDto(Municipio entity)
        {
            MunicipioDto dto = MunicipioDtoFactory.Create();
            if (entity != null)
            {
                dto.Id = entity.Id;
                dto.Pais = entity.Pais;
                dto.Codigo = entity.Codigo;
                dto.Nombre = entity.Nombre;
            }
            return dto;
        }

        public IList<MunicipioDto> EntitiesToDto(IList<Municipio> entities)
        {
            IList<MunicipioDto> dtos = new List<MunicipioDto>();

            foreach (Municipio Municipio in entities)
            {
                if (Municipio != null)
                {
                    MunicipioDto dto = EntityToDto(Municipio);
                    dtos.Add(dto);
                }
            }

            return dtos;
        }
        
        public Municipio DtoToEntity(MunicipioDto dto)
        {
            Municipio entity = MunicipioFactory.Create();
            if (dto != null)
            {
                entity.Id = dto.Id;
                entity.Pais = dto.Pais;
                entity.Codigo = dto.Codigo;
                entity.Nombre = dto.Nombre;
            }
            return entity;
        }

    }
}
