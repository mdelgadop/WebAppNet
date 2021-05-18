using WebAppCB.APIMessages.APIMessagesMappers.Implementations;
using WebAppCB.APIMessages.APIMessagesMappers.Interfaces;

namespace WebAppCB.APIMessages.Factories
{
    public class DevicesResponseMapperFactory
    {
        public static IDevicesResponseMapper Create()
        {
            IDevicesResponseMapper element = new DevicesResponseMapper();
            return element;
        }
    }
}