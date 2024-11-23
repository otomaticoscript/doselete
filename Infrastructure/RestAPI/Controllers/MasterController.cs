using Doselete.Application.UserCase;
using Doselete.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Doselete.Infrastructure.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MasterController : Controller
    {
        private readonly IMasterManager _masterManager;
        public MasterController(IMasterManager masterManager)
        {
            _masterManager = masterManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetMasters()
        {
            var result = await _masterManager.GetMasters();
            return new JsonResult(result);
        }
        
        [HttpGet("find/{findName}")]
        public async Task<IActionResult> GetMastersbyLikeName(string findName)
        {
            var result = await _masterManager.GetMastersbyLikeName(findName);
            return new JsonResult(result);
        }
        
        [HttpGet("option/{idMaster:int}")]
        public async Task<IActionResult> GetOptions(int idMaster)
        {
            var result = await _masterManager.GetOptions(idMaster);
            return new JsonResult(result);
        }
        [HttpPut]
        [HttpPost]
        public async Task<IActionResult> SetMaster(Master master)
        {
            int? id = await _masterManager.SetMaster(master);
            return new JsonResult(new { id });
        }
        [HttpPut("option/")]
        [HttpPost("option/")]
        public async Task SetOptions(MasterOption[] option)
        {
            await _masterManager.SetOptions(option);
        }
        [HttpDelete("{idMaster:int}")]
        public async Task RemoveMaster(int idMaster)
        {
            await _masterManager.RemoveMaster(idMaster);
        }

        [HttpDelete("option/{idOption:int}")]
        public async Task RemoveOptions(int idOption)
        {
            await _masterManager.RemoveOptions(idOption);
        }
    }
}
