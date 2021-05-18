using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppCB.APIMessages
{
    public class DevicesResponse : GenericAPIMessage
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public DEADto[] DEAList { get; set; }
    }
}