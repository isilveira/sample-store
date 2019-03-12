using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Resources
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {

        }
        [HttpGet]
        public ActionResult<string[]> Get()
        {
            return new string[] { "Product A", "Product B" };
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
