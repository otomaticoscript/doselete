using Doselete.Application.UserCase;
using Doselete.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Doselete.Infrastructure.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NodeController : Controller
    {
        private readonly INodeManager _nodeManager;
        public NodeController(INodeManager nodeManager)
        {
            _nodeManager = nodeManager;
        }
        #region Root
        [HttpGet("root/")]
        public async Task<IActionResult> GetNodeRoot()
        {
            var result = await _nodeManager.GetNodeRoot();
            return new JsonResult(result);
        }
        [HttpGet("tree/{IdNode:int}")]
        public async Task<IActionResult> GetNodesTree(int IdNode)
        {
            var result = await _nodeManager.GetNodesList(IdNode);
            return new JsonResult(result);
        }
        [HttpPost("root/")]
        [HttpPut("root/")]
        public async Task SetNodeRoot(Node node)
        {
            await _nodeManager.SetNodeRoot(node);
        }
        [HttpDelete("root/{IdNode:int}")]
        public async Task RemoveNodeRoot(int IdNode)
        {
            await _nodeManager.RemoveNodeRoot(IdNode);
        }
        #endregion

        #region Node
        [HttpPut]
        [HttpPost]
        public async Task SetNode(NodeList node)
        {
            await _nodeManager.SetNode(node);
        }
        [HttpDelete("{IdNode:int}")]
        public async Task RemoveNode(int IdNode)
        {
            await _nodeManager.RemoveNode(IdNode);
        }
        #endregion
    }
}