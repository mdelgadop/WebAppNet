using System.Collections.Generic;
using Business.Entities;
using Business.Repositories.Interfaces;
using System.Linq;

namespace Business.Repositories.Implementations
{
    public class DEAMockRepository : IDEARepository
    {
        private IList<DEA> _DEAList { get; set; }

        internal DEAMockRepository()
        {
            InitializeMock();
        }

        private void InitializeMock()
        {
            _DEAList = new List<DEA>();

            #region Data
            Municipio municipio = new Municipio()
                {
                    Pais = "ES",
                    Codigo = "079",
                    Nombre = "Madrid"
                };

            Add(new DEA()
            {
                Id = 1,
                Codigo = "2021-75",
                HorarioAcceso = string.Empty,
                TipoEstablecimiento = Infrastructure.Enums.TipoEstablecimientoEnum.Establecimiento_dependiente_de_una_Administracion_Publica,
                TipoTitularidad = Infrastructure.Enums.TipoTitularidadEnum.Publica,
                Municipio = municipio,
                Direccion = new Direccion()
                {
                    Id = 1,
                    Puerta = string.Empty,
                    TipoVia = Infrastructure.Enums.TipoViaEnum.CALLE,
                    Piso = string.Empty,
                    Ubicacion = "HALL INTITUTO CINEMATOGRADÍA Y ARTES AUDIOVISUALES",
                    NombreVia = "de la Magdalena",
                    PortalNumero = "10",
                    CodigoPostal = "28012",
                    CoordenadaY = 4473757,
                    CoordenadaX = 440425
                }
            });
            Add(new DEA()
            {
                Id = 2,
                Codigo = "2021-74",
                HorarioAcceso = string.Empty,
                TipoEstablecimiento = Infrastructure.Enums.TipoEstablecimientoEnum.Establecimiento_dependiente_de_una_Administracion_Publica,
                TipoTitularidad = Infrastructure.Enums.TipoTitularidadEnum.Publica,
                Municipio = municipio,
                Direccion = new Direccion()
                {
                    Id = 2,
                    Puerta = string.Empty,
                    TipoVia = Infrastructure.Enums.TipoViaEnum.CALLE,
                    Piso = string.Empty,
                    Ubicacion = "HALL INTITUTO CINEMATOGRADÍA Y ARTES AUDIOVISUALES",
                    NombreVia = "de Santa Isabel",
                    PortalNumero = "3",
                    CodigoPostal = "28012",
                    CoordenadaY = 4473701,
                    CoordenadaX = 440680
                }
            });
            Add(new DEA()
            {
                Id = 3,
                Codigo = "2021-62",
                HorarioAcceso = string.Empty,
                TipoEstablecimiento = Infrastructure.Enums.TipoEstablecimientoEnum.Otros,
                TipoTitularidad = Infrastructure.Enums.TipoTitularidadEnum.Privada,
                Municipio = municipio,
                Direccion = new Direccion()
                {
                    Id = 3,
                    Puerta = string.Empty,
                    TipoVia = Infrastructure.Enums.TipoViaEnum.CALLE,
                    Piso = string.Empty,
                    Ubicacion = "FUNDACIÓN ADEMO",
                    NombreVia = "de la Hacienda de Pavones",
                    PortalNumero = "328",
                    CodigoPostal = "28030",
                    CoordenadaY = 4472354,
                    CoordenadaX = 445835
                }
            });
            Add(new DEA()
            {
                Id = 4,
                Codigo = "2021-49",
                HorarioAcceso = "L-V 6-24 / S y D 8-21",
                TipoEstablecimiento = Infrastructure.Enums.TipoEstablecimientoEnum.Instalacion_centro_o_complejo_deportivo_con_mas_de_500_usuarios_diarios,
                TipoTitularidad = Infrastructure.Enums.TipoTitularidadEnum.Privada,
                Municipio = municipio,
                Direccion = new Direccion()
                {
                    Id = 4,
                    Puerta = string.Empty,
                    TipoVia = Infrastructure.Enums.TipoViaEnum.CALLE,
                    Piso = string.Empty,
                    Ubicacion = "EN RECEPCION EL GYM IBERICA",
                    NombreVia = "del Príncipe de Vergara",
                    PortalNumero = "113",
                    CodigoPostal = "28002",
                    CoordenadaY = 4476870,
                    CoordenadaX = 442392
                }
            });
            Add(new DEA()
            {
                Id = 5,
                Codigo = "2021-48",
                HorarioAcceso = "L-V 6-24 / S y D 8-21",
                TipoEstablecimiento = Infrastructure.Enums.TipoEstablecimientoEnum.Instalacion_centro_o_complejo_deportivo_con_mas_de_500_usuarios_diarios,
                TipoTitularidad = Infrastructure.Enums.TipoTitularidadEnum.Privada,
                Municipio = municipio,
                Direccion = new Direccion()
                {
                    Id = 5,
                    Puerta = string.Empty,
                    TipoVia = Infrastructure.Enums.TipoViaEnum.RONDA,
                    Piso = string.Empty,
                    Ubicacion = "EN RECEPCION EL GYM IBERICA",
                    NombreVia = "de Valencia",
                    PortalNumero = "1",
                    CodigoPostal = "28012",
                    CoordenadaY = 4473027,
                    CoordenadaX = 440649
                }
            });
            #endregion Data
        }

        public void Add(DEA entity)
        {
            entity.Id = _DEAList.Any() ? _DEAList.Select(d => d.Id).Max() : 1;
            _DEAList.Add(entity);
        }

        public IList<DEA> GetAll()
        {
            return _DEAList;
        }

        public DEA GetByCodigo(string codigo)
        {
            return GetAll().Where(d => d.Codigo == codigo).FirstOrDefault();
        }

        public DEA GetById(int id)
        {
            return GetAll().Where(d => d.Id == id).FirstOrDefault();
        }

        public void Remove(DEA entity)
        {
            DEA entityToRemove = _DEAList.Where(d => d.Codigo == entity.Codigo).FirstOrDefault();
            if(entityToRemove != null)
            {
                _DEAList.Remove(entityToRemove);
            }
        }

        public void Save(DEA entity)
        {
            if(entity.Id <= 0)
            {
                Add(entity);
            }
            else
            {
                Remove(entity);
                _DEAList.Add(entity);
            }
        }

        public int LastId()
        {
            return _DEAList == null || _DEAList.Count == 0 ? 0 : _DEAList.Max(d => d.Id);
        }
    }
}