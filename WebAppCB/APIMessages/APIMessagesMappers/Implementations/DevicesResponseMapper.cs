using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.Messages;
using WebAppCB.APIMessages.APIMessagesMappers.Interfaces;

namespace WebAppCB.APIMessages.APIMessagesMappers.Implementations
{
    public class DevicesResponseMapper : IDevicesResponseMapper
    {
        public IList<DevicesResponse> DtosToMessages(IList<DEAListResponse> entities)
        {
            IList<DevicesResponse> devicesResponse = new List<DevicesResponse>();

            foreach(DEAListResponse response in entities)
            {
                devicesResponse.Add(DtoToMessage(response));
            }

            return devicesResponse;
        }

        public DevicesResponse DtoToMessage(DEAListResponse response)
        {
            DevicesResponse devicesResponse = new DevicesResponse();
            devicesResponse.Success = response.Success;
            devicesResponse.Message = response.Message;
            devicesResponse.DEAList = response.DEAList.ToArray();

            return devicesResponse;
        }
    }
}