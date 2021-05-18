using WebAppCB.APIMessages.APIMessagesMappers.Implementations;
using WebAppCB.APIMessages.APIMessagesMappers.Interfaces;

namespace WebAppCB.APIMessages.Factories
{
    public class DeviceMapperFactory
    {
        public static IDeviceMapper Create()
        {
            IDeviceMapper element = new DeviceMapper();
            return element;
        }
    }
}