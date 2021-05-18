using Business.Entities;

namespace Business.Factories.Entities
{
    public class DEAFactory
    {
        public static DEA Create()
        {
            DEA element = new DEA();
            return element;
        }
    }
}