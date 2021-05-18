using Infrastructure.Enums;

namespace Application.Dtos
{
    public class DireccionDto : GenericDto
    {
        public string Puerta { get; set; }

        public TipoViaEnum TipoVia { get; set; }

        public string Piso { get; set; }

        public string Ubicacion { get; set; }

        public string NombreVia { get; set; }

        public string PortalNumero { get; set; }

        public string CodigoPostal { get; set; }

        public int CoordenadaX { get; set; }

        public int CoordenadaY { get; set; }

    }
}