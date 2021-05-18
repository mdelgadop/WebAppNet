using Business.Repositories.Implementations;
using Business.Repositories.Interfaces;
using WebAppCB.DataAccess;
using WebAppCB.DataAccess.Connections;

namespace Business.Factories.Repositories
{
    public class DEARepositoryFactory
    {
        public static IDEARepository Create()
        {
            IConnection conn = new MySQLConnection();
            IDEARepository element = new DEARepository(conn);
            return element;
        }
        public static IDEARepository CreateMock()
        {
            IDEARepository element = new DEAMockRepository();
            return element;
        }
    }
}