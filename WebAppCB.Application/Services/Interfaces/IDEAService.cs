using Application.Messages;

namespace Application.Services.Interfaces
{
    public interface IDEAService : IService
    {
        DEAListResponse GetDEAByRequest(DEAListRequest request);

        DEAResponse GetDEAElement(DEARequest request);

        ClosestDEAResponse GetClosestDEA(ClosestDEARequest request);

        CreateDEAResponse CreateDEA(CreateDEARequest request);
    }
}
