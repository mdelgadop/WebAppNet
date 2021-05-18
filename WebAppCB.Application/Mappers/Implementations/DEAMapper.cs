using System.Collections.Generic;
using Application.Dtos;
using Application.Factories.Dtos;
using Application.Mappers.Interfaces;
using Business.Entities;
using Business.Factories.Entities;

namespace Application.Mappers.Implementations
{
    public class DEAMapper : IDEAMapper
    {
        private IDireccionMapper _direccionMapper { get; set; }
        private IMunicipioMapper _municipioMapper { get; set; }

        internal DEAMapper()
        {
            _direccionMapper = new DireccionMapper();
            _municipioMapper = new MunicipioMapper();
        }

        public DEADto EntityToDto(DEA entity)
        {
            DEADto dto = DEADtoFactory.Create();
            dto.Id = entity.Id;
            dto.Codigo = entity.Codigo;
            dto.HorarioAcceso = entity.HorarioAcceso;
            dto.TipoEstablecimiento = entity.TipoEstablecimiento;
            dto.TipoTitularidad = entity.TipoTitularidad;
            dto.Municipio = _municipioMapper.EntityToDto(entity.Municipio);
            dto.Direccion = _direccionMapper.EntityToDto(entity.Direccion);

            return dto;
        }

        public IList<DEADto> EntitiesToDto(IList<DEA> entities)
        {
            IList<DEADto> dtos = new List<DEADto>();

            foreach (DEA entity in entities)
            {
                if (entity != null)
                {
                    DEADto dto = EntityToDto(entity);
                    dtos.Add(dto);
                }
            }

            return dtos;
        }

        public DEA DtoToEntity(DEADto dto)
        {
            DEA entity = DEAFactory.Create();
            entity.Id = dto.Id;
            entity.Codigo = dto.Codigo;
            entity.HorarioAcceso = dto.HorarioAcceso;
            entity.TipoEstablecimiento = dto.TipoEstablecimiento;
            entity.TipoTitularidad = dto.TipoTitularidad;
            entity.Municipio = _municipioMapper.DtoToEntity(dto.Municipio);
            entity.Direccion = _direccionMapper.DtoToEntity(dto.Direccion);

            return entity;
        }
    }
}
