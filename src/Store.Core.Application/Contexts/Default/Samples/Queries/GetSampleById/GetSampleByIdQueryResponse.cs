using BAYSOFT.Abstractions.Core.Application;
using ModelWrapper;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;
using System;
using System.Collections.Generic;

namespace Store.Core.Application.Contexts.Default.Samples.Queries.GetSampleById
{
    public class GetSampleByIdQueryResponse : ApplicationResponse<Sample>
    {
        public GetSampleByIdQueryResponse(Tuple<int, int, WrapRequest<Sample>, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) : base(tuple)
        {
        }

        public GetSampleByIdQueryResponse(WrapRequest<Sample> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
