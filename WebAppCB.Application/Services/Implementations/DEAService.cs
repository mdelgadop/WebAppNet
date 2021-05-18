using System;
using System.Collections.Generic;
using Application.Dtos;
using Application.Factories.Mappers;
using Application.Mappers.Interfaces;
using Application.Messages;
using Application.Services.Interfaces;
using Business.Repositories.Interfaces;
using System.Linq;
using Infrastructure.Enums;
using Infrastructure.Helpers;

namespace Application.Services.Implementations
{
    public class DEAService : IDEAService
    {
        private IDEARepository _deaRepository { get; set; }
        private IDEAMapper _deaMapper { get; set; }

        internal DEAService(IDEARepository deaRepository)
        {
            _deaRepository = deaRepository;
            _deaMapper = DEAMapperFactory.Create();
        }

        #region Public Methods

        //Listado de DEA's. Debe permitir ordenar por municipio y código postal. Debe permitir filtrar por municipio, código postal y si es o no de citibox.
        public DEAListResponse GetDEAByRequest(DEAListRequest request)
        {
            DEAListResponse response = new DEAListResponse();

            try
            {
                response.DEAList = _deaMapper.EntitiesToDto(_deaRepository.GetAll());

                response.DEAList = FilterList(response.DEAList, request);

                response.DEAList = OrderList(response.DEAList, request);

                response.Success = true;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.DEAList = null;
            }

            return response;
        }

        //Detalle de un elemento.
        public DEAResponse GetDEAElement(DEARequest request)    
        {
            DEAResponse response = new DEAResponse();

            try{
                response.DEAElement = _deaMapper.EntityToDto(_deaRepository.GetByCodigo(request.Codigo));

                response.Success = true;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.DEAElement = null;
            }

            return response;
        }

        //Dadas unas coordenadas, devolver el detalle del DEA más cercano. De momento no tendremos en cuenta los horarios de acceso. Si no hay un dispositivo a menos de 1km, hay que indicarlo.
        public ClosestDEAResponse GetClosestDEA(ClosestDEARequest request)
        {
            ClosestDEAResponse response = new ClosestDEAResponse();

            try
            {
                IList<DEADto> DEAList = _deaMapper.EntitiesToDto(_deaRepository.GetAll());
                double minDistance = double.MaxValue;
                DistanciaHelper helper = new DistanciaHelper();
                
                foreach(DEADto dto in DEAList)
                {
                    double distance = helper.Distancia(request.CoordenadaX, dto.Direccion.CoordenadaX, request.CoordenadaY, dto.Direccion.CoordenadaY);
                    if(distance < minDistance)
                    {
                        minDistance = distance;
                        response.DEAElement = dto;
                    }
                }

                response.Success = (response.DEAElement != null);
                response.LessThan1Km = (response.Success && minDistance <= 1);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.DEAElement = null;
            }
            
            return response;
        }

        //Registro de un nuevo dispositivo.
        public CreateDEAResponse CreateDEA(CreateDEARequest request)
        {
            CreateDEAResponse response = new CreateDEAResponse();

            try
            {
                _deaRepository.Add(_deaMapper.DtoToEntity(request.NewDEA));

                response.Success = true;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        #endregion Public Methods

        #region Private Methods

        private IList<DEADto> FilterList(IList<DEADto> listOfElements, DEAListRequest request)
        {
            if(request.HasAnyFilter())
            {
                IEnumerable<DEADto> enumerableOfElements = listOfElements;

                if(request.IsPublico)
                {
                    enumerableOfElements = enumerableOfElements.Where(d => d.TipoTitularidad == TipoTitularidadEnum.Publica);
                }
                
                if(request.IsPrivado)
                {
                    enumerableOfElements = enumerableOfElements.Where(d => d.TipoTitularidad == TipoTitularidadEnum.Privada);
                }
                
                if(!string.IsNullOrEmpty(request.FilterMunicipioCode))
                {
                    enumerableOfElements = enumerableOfElements.Where(d => d.Municipio.Codigo.Equals(request.FilterMunicipioCode));
                }
                
                if(!string.IsNullOrEmpty(request.FilterMunicipioNombre))
                {
                    enumerableOfElements = enumerableOfElements.Where(d => d.Municipio.Nombre.Equals(request.FilterMunicipioNombre));
                }

                listOfElements = enumerableOfElements.ToList();
            }

            return listOfElements;
        }
        
        private IList<DEADto> OrderList(IList<DEADto> listOfElements, DEAListRequest request)
        {
            if(request.OrderByCodigoPostal || request.OrderByCodigoPostal)
            {
                IOrderedEnumerable<DEADto> ordered = listOfElements.OrderBy(d => d.Id);

                if(request.OrderByCodigoPostal)
                {
                    ordered = ordered.ThenBy(d => d.Direccion.CodigoPostal);
                }
                else if(request.OrderByMunicipio)
                {
                    ordered = ordered.ThenBy(d => d.Municipio.Nombre);
                }

                listOfElements = ordered.ToList();
            }

            return listOfElements;
        }
        
        #endregion Private Methods
    }
}
