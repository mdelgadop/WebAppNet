using Application.Dtos;

namespace Application.Messages
{
    public class ClosestDEAResponse : GenericResponse
    {
        public DEADto DEAElement { get; set; }

        public decimal Distance { get; set; }
        
        public bool LessThan1Km { get; set; }
    }
}
