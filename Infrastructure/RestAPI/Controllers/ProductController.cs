using System.Text;
using Doselete.Application.UserCase;
using Doselete.Application.UserCase.Mapper;
using Doselete.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Doselete.Infrastructure.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ITemplateManager _templateManager;
        public ProductController(IProductManager productManager, ITemplateManager templateManager)
        {
            _productManager = productManager;
            _templateManager = templateManager;

        }
        //[ApiKey]
        [HttpGet("{idProduct}")]
        public async Task<IActionResult> GetProductCache(int idProduct)
        {
            var nodes = await _productManager.GetProductListNode(idProduct);
            var result = NodeMapper.MapperTree(nodes);
            var builder = await NodeMapper.MapperJsonByTree(result, _templateManager);           
            return Ok(builder.ToString());

        }

        private StringBuilder Recursive(Tree<NodeList> result)
        {
            var builder = new StringBuilder();

            if (result.element.JsonName != "")
            {
                builder.Append("{\"" + result.element.JsonName + "\":");
            }
            if (result.element.JsonValue != "")
            {
                builder.Append(result.element.JsonValue.Replace("}", ""));
            }
            else
            {
                builder.Append("{");
            }
            foreach (var node in result.children)
            {
                builder.Append(Recursive(node));

            }
            builder.Append("}");

            return builder;
        }

        //[ApiKey]
        [HttpGet("job/{idProduct}")]
        public async Task<IActionResult> SetProductCache(int idProduct)
        {
            await _productManager.SetCacheFromApiService(idProduct);
            bool ok = true;
            return new JsonResult(new { ok });

        }

    }
}