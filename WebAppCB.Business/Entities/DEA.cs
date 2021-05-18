using Infrastructure.Enums;

namespace Business.Entities
{
    public class DEA : GenericEntity
    {
        public string Codigo { get; set; }

        public TipoEstablecimientoEnum TipoEstablecimiento { get; set; }

        public TipoTitularidadEnum TipoTitularidad { get; set; }

        public string HorarioAcceso { get; set; }

        public Direccion Direccion { get; set; }
        
        public Municipio Municipio { get; set; }
    }
}