using Doselete.Application.UserCase;
using Doselete.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Doselete.Infrastructure.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemplateController : Controller
    {
        private readonly ITemplateManager _templateManager;
        public TemplateController(ITemplateManager templateManager)
        {
            _templateManager = templateManager;
        }
        #region Template
        [HttpGet]
        public async Task<IActionResult> GetTemplates()
        {
            var result = await _templateManager.GetTemplates();
            return new JsonResult(result);
        }
        
        [HttpGet("find/{findName}")]
        public async Task<IActionResult> GetTemplatesbyLikeName(string findName)
        {

            List<Template> result = await _templateManager.GetTemplates();
            return new JsonResult(result);
        }
        [HttpPut]
        [HttpPost]
        public async Task SetTemplate(Template template)
        {
            await _templateManager.SetTemplate(template);
        }
        [HttpDelete("{idTemplate:int}")]
        public async Task RemoveTemplate(int idTemplate)
        {
            await _templateManager.RemoveTemplate(idTemplate);
        }
        #endregion

        #region Field
        [HttpGet("field/{idTemplate:int}")]
        public async Task<IActionResult> GetFields(int idTemplate)
        {
            var result = await _templateManager.GetFields(idTemplate);
            return new JsonResult(result);
        }
        [HttpPut("field/")]
        [HttpPost("field/")]
        public async Task SetFields(TemplateField[] fields)
        {
            await _templateManager.SetFields(fields);
        }
        [HttpDelete("field/{idField:int}")]
        public async Task RemoveField(int idField)
        {
            //Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(fields));
            await _templateManager.RemoveField(idField);
        }
        #endregion

        #region Children
        [HttpGet("children/{idTemplate:int}")]
        public async Task<IActionResult> GetChildrens(int idTemplate)
        {
            var result = await _templateManager.GetChildrens(idTemplate);
            return new JsonResult(result);
        }
        [HttpGet("children/node/{idNode:int}")]
        public async Task<IActionResult> GetChildrenByIdNode(int idNode)
        {
            var result = await _templateManager.GetChildrenByIdNode(idNode);
            return new JsonResult(result);
        }
        [HttpPut("children/")]
        [HttpPost("children/")]
        public async Task SetChildrens(TemplateAllowedChildren[] childrens)
        {
            await _templateManager.SetChildrens(childrens);
        }
        [HttpDelete("children/{idAllowed}")]
        public async Task RemoveChildren(int idAllowed)
        {
            await _templateManager.RemoveChildren(idAllowed);
        }
        #endregion

    }
}
