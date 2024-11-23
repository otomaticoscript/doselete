using Doselete.Domain.Repository.Data;
using Doselete.Domain.Entity;
namespace Doselete.Application.UserCase
{
    public interface INodeManager
    {
        public Task<List<NodeRoot>> GetNodeRoot();
        public Task<List<NodeList>> GetNodesList(int IdNodeRoot);
        public Task RemoveNodeRoot(int IdNode);
        public Task SetNodeRoot(Node node);
        public Task SetNode(NodeList node);
        public Task RemoveNode(int IdNode);

    }

    public class NodeManager : INodeManager
    {
        private readonly INodeData _nodeData;
        private readonly INodeRelationData _nodeRelationData;
        public NodeManager(INodeData nodeData, INodeRelationData nodeRelationData)
        {
            _nodeData = nodeData;
            _nodeRelationData = nodeRelationData;
        }
        public async Task<List<NodeRoot>> GetNodeRoot()
        {
            return await _nodeData.GetRootAsync();
        }
        public async Task<List<NodeList>> GetNodesList(int IdNodeRoot)
        {
            return await _nodeData.GetNodesListAsync(IdNodeRoot);
        }
        public async Task RemoveNodeRoot(int IdNode)
        {
            List<NodeRelation> relations = await _nodeRelationData.GetNodeRelationByIdNodeRootAsync(IdNode);
            await _nodeRelationData.DeleteNodeRelationByIdNodeRootAsync(IdNode);
            await _nodeData.DeleteNodesAsync(relations.Select(el => el.IdNode).ToArray());
            await _nodeData.DeleteNodeAsync(IdNode);
        }
        public async Task SetNodeRoot(Node node)
        {
            node.Modify = DateTime.UtcNow;
            if (node.Id != null)
            {
                await _nodeData.UpdateNodeAsync(node);
            }
            else
            {
                await _nodeData.InsertNodeAsync(node);
            }
        }
        public async Task SetNode(NodeList node)
        {
            if (node.Id != null)
            {
                await _nodeData.UpdateNodeAsync(node);
            }
            else
            {
                await _nodeData.InsertNodeAsync(node);
                NodeRelation? relation = await _nodeRelationData.GetNodeRelationByIdNodeAsync(node.IdNodeParent ?? 0);
                if (relation != null)
                {
                    relation.IdNode = node.Id ?? 0;
                }
                else
                {
                    relation = new NodeRelation()
                    {
                        IdNode = node.Id ?? 0,
                        IdNodeParent = node.IdNodeParent ?? 0,
                        IdNodeRoot = node.IdNodeParent ?? 0,
                    };
                }
                await _nodeRelationData.InsertNodeRelationAsync(relation);

            }
        }
        public async Task RemoveNode(int IdNode)
        {
            List<NodeRelation> relations = await _nodeRelationData.GetNodeRelationByIdNodeParentAsync(IdNode);

            if (relations.Count > 0)
            {
                int[] nodeChildrens = relations.Select(p => p.IdNodeParent).Distinct().ToArray();
                foreach (var el in nodeChildrens)
                {
                    await _nodeRelationData.DeleteNodeRelationAsync(el);
                }
                await _nodeData.DeleteNodesAsync(relations.Select(el => el.IdNode).ToArray());
            }
            await _nodeRelationData.DeleteNodeRelationAsync(IdNode);
            await _nodeData.DeleteNodeAsync(IdNode);
        }
    }
}