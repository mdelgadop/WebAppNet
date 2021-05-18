using System.Collections.Generic;
using Business.Entities;
using Business.Repositories.Interfaces;
using WebAppCB.DataAccess;

namespace Business.Repositories.Implementations
{
    public class DireccionRepository : IDireccionRepository
    {
        private IConnection _connection { get; set; }

        internal DireccionRepository(IConnection connection)
        {
            _connection = connection;
        }

        public void Add(Direccion entity)
        {
            if (entity.Id >= 0)
            {
                string query = string.Format("insert into direcciones (puerta, tipovia, piso, ubicacion, nombrevia, portalnumero, codigopostal, coordenadax, coordenaday) values ('{0}', {1}, '{2}', '{3}', '{4}', '{5}', '{6}', {7}, {8});",
                    _connection.CleanValue(entity.Puerta),
                    (int)entity.TipoVia,
                    _connection.CleanValue(entity.Piso),
                    _connection.CleanValue(entity.Ubicacion),
                    _connection.CleanValue(entity.NombreVia),
                    _connection.CleanValue(entity.PortalNumero),
                    _connection.CleanValue(entity.CodigoPostal),
                    entity.CoordenadaX,
                    entity.CoordenadaY
                    );
                _connection.ExecuteNonQuery(query);
            }
        }

        public IList<Direccion> GetAll()
        {
            string query = string.Format("select direccion_id, puerta, tipovia, piso, ubicacion, nombrevia, portalnumero, codigopostal, coordenadax, coordenaday from direcciones;");
            IList<string[]> rows = _connection.ExecuteQuery(query);
            IList<Direccion> elements = new List<Direccion>();
            foreach (string[] row in rows)
            {
                Direccion element = StringArrayToDireccion(row);
                elements.Add(element);
            }
            return elements;
        }

        public Direccion GetById(int id)
        {
            string query = string.Format("select direccion_id, puerta, tipovia, piso, ubicacion, nombrevia, portalnumero, codigopostal, coordenadax, coordenaday from direcciones where direccion_id = {0};", id);
            IList<string[]> rows = _connection.ExecuteQuery(query);
            Direccion element = null;
            foreach (string[] row in rows)
            {
                element = StringArrayToDireccion(row);
            }
            return element;
        }

        public void Remove(Direccion entity)
        {
            if(entity.Id >= 0)
            {
                string query = string.Format("delete from from direcciones where direccion_id = {0};", entity.Id);
                _connection.ExecuteNonQuery(query);
            }
        }

        public void Save(Direccion entity)
        {
            if (entity.Id >= 0)
            {
                string query = string.Format("update direcciones set puerta='{1}', tipovia={2}, piso='{3}', ubicacion='{4}', nombrevia='{5}', portalnumero='{6}', codigopostal='{7}', coordenadax={8}, coordenaday={9} where direccion_id = {0};",
                    entity.Id,
                    entity.Puerta,
                    (int)entity.TipoVia,
                    entity.Piso,
                    entity.Ubicacion,
                    entity.NombreVia,
                    entity.PortalNumero,
                    entity.CodigoPostal,
                    entity.CoordenadaX,
                    entity.CoordenadaY
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
        
        #region Private methods
        private Direccion StringArrayToDireccion(string[] row)
        {
            return new Direccion()
            {
                Id = int.Parse(row[0]),
                Puerta = row[1],
                TipoVia = (Infrastructure.Enums.TipoViaEnum)(int.Parse(row[2])),
                Piso = row[3],
                Ubicacion = row[4],
                NombreVia = row[5],
                PortalNumero = row[6],
                CodigoPostal = row[7],
                CoordenadaX = int.Parse(row[8]),
                CoordenadaY = int.Parse(row[9])
            };
        }
        #endregion Private methods

    }
}