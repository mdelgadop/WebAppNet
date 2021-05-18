using Application.Dtos;

namespace Application.Messages
{
    public class DEAResponse : GenericResponse
    {
        public DEADto DEAElement { get; set; }
    }
}
