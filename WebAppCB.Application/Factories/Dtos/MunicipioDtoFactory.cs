using Application.Dtos;

namespace Application.Factories.Dtos
{
    public class MunicipioDtoFactory
    {
        public static MunicipioDto Create()
        {
            MunicipioDto element = new MunicipioDto();
            return element;
        }
    }
}
