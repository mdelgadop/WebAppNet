using Application.Dtos;
using Application.Factories.Services;
using Application.Messages;
using Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppCB.APIMessages;
using WebAppCB.APIMessages.APIMessagesMappers.Interfaces;
using WebAppCB.APIMessages.Factories;

namespace WebAppCB.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/devices")]
    public class DevicesController : ApiController
    {
        IDEAService _service = DEAServiceFactory.Create();

        //http://localhost:1898/api/devices/echoping
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [Route("devices")]
        public DevicesResponse Devices(DEAListRequest request)
        {
            DEAListResponse response = _service.GetDEAByRequest(request);
            IDevicesResponseMapper mapper = DevicesResponseMapperFactory.Create();

            return mapper.DtoToMessage(response);
        }

        [HttpGet]
        [Route("device/{device_id}")]
        public DEADto Device(string device_id)
        {
            DEARequest request = new DEARequest()
            {
                Codigo = device_id
            };

            DEAResponse response = _service.GetDEAElement(request);

            if(response != null && response.DEAElement != null)
            {
                return response.DEAElement;
            }
            else
            {
                return null;
            }
        }

        [Route("create", Name="Create")]
        [System.Web.Http.Description.ResponseType(typeof(DEADto))]
        public IHttpActionResult Create(DEADto newElement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CreateDEARequest request = new CreateDEARequest()
            {
                NewDEA = newElement
            };

            CreateDEAResponse response = _service.CreateDEA(request);

            return CreatedAtRoute("create", new { id = newElement.Codigo }, newElement);
        }
        
        [Route("nearest", Name = "Nearest")]
        [System.Web.Http.Description.ResponseType(typeof(DEADto))]
        public IHttpActionResult Nearest(ClosestDEARequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClosestDEAResponse response = _service.GetClosestDEA(request);

            return CreatedAtRoute("nearest", new { id = response.Success }, response.DEAElement);
        }
    }
}