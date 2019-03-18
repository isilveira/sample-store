﻿using MediatR;
using System;

namespace StoreAPI.Core.Application.Products.Queries.GetProductsByFilter
{
    public class GetProductsByFilterQuery: IRequest<GetProductsByFilterQueryResponse>
    {
        public int? CategoryID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Specifications { get; set; }
        public int? Amount { get; set; }
        public decimal? Value { get; set; }

        public DateTime? RegistrationDate { get; set; }
        public bool? IsVisible { get; set; }
    }
}
