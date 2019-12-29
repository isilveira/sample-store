﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ModelWrapper;
using Store.Core.Application.Bases;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Resources._Bases
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceControllerBase: ControllerBase
    {
        private IMediator _mediator;
        private IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        public async Task<ActionResult<TResponse>> Send<TEntity, TResponse>(RequestBase<TEntity, TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
            where TEntity : class
            where TResponse : ResponseBase<TEntity>
        {
            try
            {
                return Ok(await Mediator.Send(request, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(new WrapResponse(400, 4001001, request.RequestObject, null, ex.Message, 0));
            }
        }

        public async Task<TResponse> SendRequest<TEntity, TResponse>(RequestBase<TEntity, TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
            where TEntity : class
            where TResponse : ResponseBase<TEntity>
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
