using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Images.Queries.GetImagesByFilter
{
    public class GetImagesByFilterQuery:IRequest<GetImagesByFilterQueryResponse>
    {
    }
}
