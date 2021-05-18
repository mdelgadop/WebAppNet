using System.Collections.Generic;
using Business.Entities;
using Business.Repositories.Interfaces;
using WebAppCB.DataAccess;

namespace Business.Repositories.Implementations
{
    public class MunicipioRepository : IMunicipioRepository
    {
        private IConnection _connection { get; set; }

        internal MunicipioRepository(IConnection connection)
        {
            _connection = connection;
        }

        public void Add(Municipio entity)
        {
            if (entity.Id == 0)
            {
                string query = string.Format("insert into municipios (pais, codigo, nombre) values ('{0}', '{1}', '{2}');",
                    "ES",
                    _connection.CleanValue(entity.Codigo),
                    _connection.CleanValue(entity.Nombre)
                    );
                _connection.ExecuteNonQuery(query);
            }
        }

        public IList<Municipio> GetAll()
        {
            string query = string.Format("select municipio_id, pais, codigo, nombre from municipios;");
            IList<string[]> rows = _connection.ExecuteQuery(query);
            IList<Municipio> elements = new List<Municipio>();
            foreach (string[] row in rows)
            {
                Municipio element = StringArrayToMunicipio(row);
                elements.Add(element);
            }
            return elements;
        }

        public Municipio GetById(int id)
        {
            string query = string.Format("select municipio_id, pais, codigo, nombre from municipios where municipio_id = {0};", id);
            IList<string[]> rows = _connection.ExecuteQuery(query);
            Municipio element = null;
            foreach (string[] row in rows)
            {
                element = StringArrayToMunicipio(row);
            }
            return element;
        }

        public Municipio GetByCodigo(string codigo)
        {
            string query = string.Format("select municipio_id, pais, codigo, nombre from municipios where codigo = '{0}';", codigo);
            IList<string[]> rows = _connection.ExecuteQuery(query);
            Municipio element = null;
            foreach (string[] row in rows)
            {
                element = StringArrayToMunicipio(row);
            }
            return element;
        }

        public void Remove(Municipio entity)
        {
            if (entity.Id >= 0)
            {
                string query = string.Format("delete from from municipios where municipio_id = {0};", entity.Id);
                _connection.ExecuteNonQuery(query);
            }
        }

        public void Save(Municipio entity)
        {
            if (entity.Id >= 0)
            {
                string query = string.Format("update municipios set pais='{1}', codigo='{2}', nombre='{3}' where direccion_id = {0};",
                    entity.Id,
                    entity.Pais,
                    entity.Codigo,
                    entity.Nombre
                    );
                _connection.ExecuteNonQuery(query);
            }
        }

        public int LastId()
        {
            string query = string.Format("select max(municipio_id) from municipios;");
            IList<string[]> rows = _connection.ExecuteQuery(query);
            int element = 0;
            foreach (string[] row in rows)
            {
                element = int.Parse(row[0]);
            }
            return element;
        }

        #region Private Methods
        private Municipio StringArrayToMunicipio(string[] row)
        {
            return new Municipio()
            {
                Id = int.Parse(row[0]),
                Pais = row[1],
                Codigo = row[2],
                Nombre = row[3]
            };
        }
        #endregion Private Methods
    }
}