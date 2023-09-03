﻿using BAYSOFT.Abstractions.Core.Application;
using Store.Core.Domain.Default.Samples.Entities;
using ModelWrapper;
using System;
using System.Collections.Generic;

namespace Store.Core.Application.Default.Samples.Commands
{
    public class PatchSampleCommandResponse : ApplicationResponse<Sample>
    {
        public PatchSampleCommandResponse(Tuple<int, int, WrapRequest<Sample>, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) : base(tuple)
        {
        }

        public PatchSampleCommandResponse(WrapRequest<Sample> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}