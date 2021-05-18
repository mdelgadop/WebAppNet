using Application.Dtos;
using Application.Mappers.Implementations;
using Application.Mappers.Interfaces;

namespace Application.Factories.Mappers
{
    public class DEAMapperFactory
    {
        public static IDEAMapper Create()
        {
            IDEAMapper element = new DEAMapper();
            return element;
        }
    }
}
