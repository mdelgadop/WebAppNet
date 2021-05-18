using System;
using System.Collections.Generic;
using Application.Dtos;
using WebAppCB.APIMessages.APIMessagesMappers.Interfaces;

namespace WebAppCB.APIMessages.APIMessagesMappers.Implementations
{
    public class DeviceMapper : IDeviceMapper
    {
        public Device DtoToMessage(DEADto entity)
        {
            Device device = new Device()
            {
                id = entity.Codigo,
                address = entity.Direccion.NombreVia,
                device_location = entity.Direccion.Ubicacion,
                locality = entity.Municipio.Nombre,
                postal_code = entity.Direccion.CodigoPostal,
                lat = entity.Direccion.CoordenadaX,
                lon = entity.Direccion.CoordenadaY
            };

            return device;
        }

        public IList<Device> DtosToMessages(IList<DEADto> dtos)
        {
            IList<Device> devices = new List<Device>();

            foreach(DEADto dto in dtos)
            {
                devices.Add(DtoToMessage(dto));
            }

            return devices;
        }

    }
}