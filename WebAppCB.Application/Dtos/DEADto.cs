using Infrastructure.Enums;

namespace Application.Dtos
{
    public class DEADto : GenericDto
    {
        public string Codigo { get; set; }

        public TipoEstablecimientoEnum TipoEstablecimiento { get; set; }

        public TipoTitularidadEnum TipoTitularidad { get; set; }

        public string HorarioAcceso { get; set; }
        
        public DireccionDto Direccion { get; set; }
        
        public MunicipioDto Municipio { get; set; }
    }
}