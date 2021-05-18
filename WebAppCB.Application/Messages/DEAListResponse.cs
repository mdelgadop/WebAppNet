using System.Collections.Generic;
using Application.Dtos;

namespace Application.Messages
{
    public class DEAListResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public IList<DEADto> DEAList { get; set; }
    }
}