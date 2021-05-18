using Application.Dtos;
using System.Collections.Generic;

namespace WebAppCB.APIMessages.APIMessagesMappers
{
    public interface IAPIMessageMapper<Dto, APIMessage>
        where Dto : class
        where APIMessage : GenericAPIMessage
    {
        IList<APIMessage> DtosToMessages(IList<Dto> entities);

        APIMessage DtoToMessage(Dto entity);
    }
}
