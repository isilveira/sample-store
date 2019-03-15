using StoreAPI.Core.Application.Interfaces.Responses;

namespace StoreAPI.Core.Application.Bases
{
    public class CommandResponse<TResponse, TDTO> : Response<TResponse, TDTO>, ICommandResponse<TResponse, TDTO>
    {
        public string Message { get; set; }
    }
}
