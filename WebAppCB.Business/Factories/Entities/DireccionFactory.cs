using Business.Entities;

namespace Business.Factories.Entities
{
    public class DireccionFactory
    {
        public static Direccion Create()
        {
            Direccion element = new Direccion();
            return element;
        }
    }
}