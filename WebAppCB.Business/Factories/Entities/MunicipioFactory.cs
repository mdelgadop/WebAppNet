using Business.Entities;

namespace Business.Factories.Entities
{
    public class MunicipioFactory
    {
        public static Municipio Create()
        {
            Municipio element = new Municipio();
            return element;
        }
    }
}