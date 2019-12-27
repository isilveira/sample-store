﻿using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Images.Queries.GetImagesByFilter
{
    public class GetImagesByFilterQuery : RequestBase<Image, GetImagesByFilterQueryResponse>
    {
        public GetImagesByFilterQuery()
        {
            ConfigKeys(x => x.ImageID);

            ConfigSuppressedProperties(x => x.Product);

            ConfigSuppressedResponseProperties(x => x.Product);
        }
    }
}
