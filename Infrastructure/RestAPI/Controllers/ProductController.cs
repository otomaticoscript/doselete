using Doselete.Application.UserCase;
using Doselete.Application.UserCase.Mapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpGet("{idProduct}")]
        public async Task<IActionResult> GetProductCache(int idProduct)
        {
            var nodes = await _productManager.GetProductListNode(idProduct);
            var result = NodeMapper.MapperTree(nodes);
            var builder = await NodeMapper.MapperJsonByTree(result, _templateManager);           
            return Ok(FormatJson(builder.ToString()));
        }

        [HttpPut("{idProduct}")]
        public async Task<IActionResult> SetProductCache(int idProduct)
        {
            await _productManager.SetCacheFromApiService(idProduct);
            bool ok = true;
            return new JsonResult(new { ok });
        }

        private static string FormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }
    }
}