using Business.Repositories.Implementations;
using Business.Repositories.Interfaces;
using WebAppCB.DataAccess;
using WebAppCB.DataAccess.Connections;

namespace Business.Factories.Repositories
{
    public class MunicipioRepositoryFactory
    {
        public static IMunicipioRepository Create()
        {
            IConnection conn = new MySQLConnection();
            IMunicipioRepository element = new MunicipioRepository(conn);
            return element;
        }

        public static IMunicipioRepository Create(IConnection conn)
        {
            IMunicipioRepository element = new MunicipioRepository(conn);
            return element;
        }
    }
}
