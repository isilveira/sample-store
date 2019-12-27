﻿using MediatR;
using ModelWrapper;

namespace StoreAPI.Core.Application.Bases
{
    public abstract class RequestBase<TEntity, TResponse> : WrapRequest<TEntity>, IRequest<TResponse>
        where TEntity : class
        where TResponse : ResponseBase<TEntity>
    {
    }
}
