using System.Collections.Generic;
using Application.Dtos;
using Application.Factories.Dtos;
using Application.Mappers.Interfaces;
using Business.Entities;
using Business.Factories.Entities;

namespace Application.Mappers.Implementations
{
    public class DireccionMapper : IDireccionMapper
    {
        
        public DireccionDto EntityToDto(Direccion entity)
        {
            DireccionDto dto = DireccionDtoFactory.Create();
            dto.Id = entity.Id;
            dto.CodigoPostal = entity.CodigoPostal;
            dto.CoordenadaX = entity.CoordenadaX;
            dto.CoordenadaY = entity.CoordenadaY;
            dto.NombreVia = entity.NombreVia;
            dto.Piso = entity.Piso;
            dto.PortalNumero = entity.PortalNumero;
            dto.Puerta = entity.Puerta;
            dto.TipoVia = entity.TipoVia;
            dto.Ubicacion = entity.Ubicacion;

            return dto;
        }

        public IList<DireccionDto> EntitiesToDto(IList<Direccion> entities)
        {
            IList<DireccionDto> dtos = new List<DireccionDto>();

            foreach (Direccion Direccion in entities)
            {
                if (Direccion != null)
                {
                    DireccionDto dto = EntityToDto(Direccion);
                    dtos.Add(dto);
                }
            }

            return dtos;
        }
        
        public Direccion DtoToEntity(DireccionDto dto)
        {
            Direccion entity = DireccionFactory.Create();
            entity.Id = dto.Id;
            entity.CodigoPostal = dto.CodigoPostal;
            entity.CoordenadaX = dto.CoordenadaX;
            entity.CoordenadaY = dto.CoordenadaY;
            entity.NombreVia = dto.NombreVia;
            entity.Piso = dto.Piso;
            entity.PortalNumero = dto.PortalNumero;
            entity.Puerta = dto.Puerta;
            entity.TipoVia = dto.TipoVia;
            entity.Ubicacion = dto.Ubicacion;

            return entity;
        }
    }
}
