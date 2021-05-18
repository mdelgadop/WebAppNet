using Business.Repositories.Implementations;
using Business.Repositories.Interfaces;
using WebAppCB.DataAccess;
using WebAppCB.DataAccess.Connections;

namespace Business.Factories.Repositories
{
    public class DireccionRepositoryFactory
    {
        public static IDireccionRepository Create()
        {
            IConnection conn = new MySQLConnection();
            IDireccionRepository element = new DireccionRepository(conn);
            return element;
        }

        public static IDireccionRepository Create(IConnection conn)
        {
            IDireccionRepository element = new DireccionRepository(conn);
            return element;
        }
    }
}
