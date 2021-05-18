using System.Collections.Generic;
using Business.Entities;
using Business.Factories.Repositories;
using Business.Repositories.Interfaces;
using WebAppCB.DataAccess;

namespace Business.Repositories.Implementations
{
    public class DEARepository : IDEARepository
    {
        private IConnection _connection { get; set; }
        private IMunicipioRepository _municipioRepository { get; set; }
        private IDireccionRepository _direccionRepository { get; set; }

        internal DEARepository(IConnection connection)
        {
            _connection = connection;
            _municipioRepository = MunicipioRepositoryFactory.Create(_connection);
            _direccionRepository = DireccionRepositoryFactory.Create(_connection);
        }

        public void Add(DEA entity)
        {
            if (entity.Id == 0)
            {
                int municipioId = 0;
                if (entity.Municipio != null)
                {
                    if (entity.Municipio.Id == 0 && !string.IsNullOrEmpty(entity.Municipio.Codigo))
                    {
                        Municipio myMunicipio = _municipioRepository.GetByCodigo(entity.Municipio.Codigo);
                        if (myMunicipio == null)
                        {
                            _municipioRepository.Add(entity.Municipio);
                            municipioId = _municipioRepository.LastId();
                        }
                        else
                        {
                            municipioId = myMunicipio.Id;
                        }
                    }
                    else
                    {
                        municipioId = entity.Municipio.Id;
                    }
                }

                _direccionRepository.Add(entity.Direccion);
                int direccionId = _direccionRepository.LastId();

                string query = string.Format("insert into deas (codigo, tipoestablecimiento, tipotitularidad, horarioacceso, direccion_id, municipio_id) values ('{0}', {1}, {2}, '{3}', {4}, {5});",
                    _connection.CleanValue(entity.Codigo),
                    (int)entity.TipoEstablecimiento,
                    (int)entity.TipoTitularidad,
                    _connection.CleanValue(entity.HorarioAcceso),
                    direccionId,
                    municipioId
                    );
                _connection.ExecuteNonQuery(query);
            }
        }

        public IList<DEA> GetAll()
        {
            string query = string.Format("select dea_id, codigo, tipoestablecimiento, tipotitularidad, horarioacceso, direccion_id, municipio_id from deas;");
            IList<string[]> rows = _connection.ExecuteQuery(query);
            IList<DEA> elements = new List<DEA>();
            Dictionary<int, Municipio> dictMunicipios = new Dictionary<int, Municipio>();
            foreach (string[] row in rows)
            {
                DEA element = new DEA()
                {
                    Id = int.Parse(row[0]),
                    Codigo = row[1],
                    TipoEstablecimiento = (Infrastructure.Enums.TipoEstablecimientoEnum)(int.Parse(row[2])),
                    TipoTitularidad = (Infrastructure.Enums.TipoTitularidadEnum)(int.Parse(row[3])),
                    HorarioAcceso = row[4],
                    Direccion = _direccionRepository.GetById(int.Parse(row[5]))
                };

                int idMunicipio = int.Parse(row[6]);
                if (idMunicipio > 0)
                {
                    if (dictMunicipios.ContainsKey(idMunicipio))
                    {
                        element.Municipio = dictMunicipios[idMunicipio];
                    }
                    else
                    {
                        element.Municipio = _municipioRepository.GetById(idMunicipio);
                        dictMunicipios.Add(idMunicipio, element.Municipio);
                    }
                }

                elements.Add(element);
            }
            return elements;
        }

        public DEA GetByCodigo(string codigo)
        {
            string query = string.Format("select dea_id, codigo, tipoestablecimiento, tipotitularidad, horarioacceso, direccion_id, municipio_id from deas where codigo='{0}';", codigo);
            IList<string[]> rows = _connection.ExecuteQuery(query);
            DEA element = null;
            foreach (string[] row in rows)
            {
                element = new DEA()
                {
                    Id = int.Parse(row[0]),
                    Codigo = row[1],
                    TipoEstablecimiento = (Infrastructure.Enums.TipoEstablecimientoEnum)(int.Parse(row[2])),
                    TipoTitularidad = (Infrastructure.Enums.TipoTitularidadEnum)(int.Parse(row[3])),
                    HorarioAcceso = row[4],
                    Direccion = _direccionRepository.GetById(int.Parse(row[5])),
                    Municipio = _municipioRepository.GetById(int.Parse(row[6]))
                };
            }
            return element;
        }

        public DEA GetById(int id)
        {
            string query = string.Format("select dea_id, codigo, tipoestablecimiento, tipotitularidad, horarioacceso, direccion_id, municipio_id from deas where dea_id={0};", id);
            IList<string[]> rows = _connection.ExecuteQuery(query);
            DEA element = null;
            foreach (string[] row in rows)
            {
                element = new DEA()
                {
                    Id = int.Parse(row[0]),
                    Codigo = row[1],
                    TipoEstablecimiento = (Infrastructure.Enums.TipoEstablecimientoEnum)(int.Parse(row[2])),
                    TipoTitularidad = (Infrastructure.Enums.TipoTitularidadEnum)(int.Parse(row[3])),
                    HorarioAcceso = row[4],
                    Direccion = _direccionRepository.GetById(int.Parse(row[5])),
                    Municipio = _municipioRepository.GetById(int.Parse(row[6]))
                };
            }
            return element;
        }

        public void Remove(DEA entity)
        {
            if (entity.Id >= 0)
            {
                string query = string.Format("delete from from deas where dea_id = {0};", entity.Id);
                _connection.ExecuteNonQuery(query);
                _municipioRepository.Remove(entity.Municipio);
                _direccionRepository.Remove(entity.Direccion);
            }
        }

        public void Save(DEA entity)
        {
            if (entity.Id > 0)
            {
                if(entity.Municipio != null)
                    _municipioRepository.Save(entity.Municipio);

                _direccionRepository.Save(entity.Direccion);

                string query = string.Format("update deas set codigo='{0}', tipoestablecimiento={1}, tipotitularidad={2}, horarioacceso='{3}', municipio_id={4} where dea_id={5};",
                    entity.Codigo,
                    (int)entity.TipoEstablecimiento,
                    (int)entity.TipoTitularidad,
                    entity.HorarioAcceso,
                    entity.Municipio == null ? 0 : entity.Municipio.Id,
                    entity.Id
                    );
                _connection.ExecuteNonQuery(query);
            }
        }

        public int LastId()
        {
            string query = string.Format("select max(direccion_id) from direcciones;");
            IList<string[]> rows = _connection.ExecuteQuery(query);
            int element = 0;
            foreach (string[] row in rows)
            {
                element = int.Parse(row[0]);
            }
            return element;
        }

    }
}