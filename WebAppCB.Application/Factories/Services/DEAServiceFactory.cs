using Application.Services.Implementations;
using Application.Services.Interfaces;
using Business.Factories.Repositories;

namespace Application.Factories.Services
{
    public class DEAServiceFactory
    {
        public static IDEAService Create()
        {
            IDEAService element = new DEAService(DEARepositoryFactory.Create());
            return element;
        }

        public static IDEAService CreateMock()
        {
            IDEAService element = new DEAService(DEARepositoryFactory.CreateMock());
            return element;
        }
    }
}
