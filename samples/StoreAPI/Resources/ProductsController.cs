using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Core.Application.Products.Queries.GetProductsByFilter;
using System;
using System.Threading.Tasks;

namespace StoreAPI.Resources
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IMediator Mediator { get; set; }
        public ProductsController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetProductsByFilterQueryResponse>> Get([FromQuery]GetProductsByFilterQuery request)
        {
            try
            {
                return Ok(await Mediator.Send(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{productid}")]
        public ActionResult<string> Get(int productid)
        {
            return "Some Product";
        }
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        [HttpPut("{productid}")]
        public void Put(int productid, [FromBody] string value)
        {

        }

        [HttpPatch("{productid}")]
        public void Patch(int productid, [FromBody] string value)
        {

        }

        [HttpDelete("{productid}")]
        public void Delete(int productid)
        {

        }
    }
}
