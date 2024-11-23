using Doselete.Domain.Entity;
using Doselete.Domain.Repository.Data;
using Doselete.Domain.Repository.Service;
using Newtonsoft.Json;

namespace Doselete.Application.UserCase
{
    public interface IProductManager
    {
        public Task<List<NodeList>> GetProductListNode(int IdProduct);
        public Task SetCacheFromApiService(int IdProduct);

    }

    public class ProductManager : IProductManager
    {
        private readonly INodeData _nodeData;
        private readonly INodeRelationData _nodeRelationData;
        private readonly IProductData<TvMazeProduct> _productData;
        private readonly ITvMazeService _productService;
        public ProductManager(INodeData nodeData, IProductData<TvMazeProduct> productData, ITvMazeService productService, INodeRelationData nodeRelationData)
        {
            _nodeData = nodeData;
            _productData = productData;
            _productService = productService;
            _nodeRelationData = nodeRelationData;
        }

        public async Task<List<NodeList>> GetProductListNode(int IdProduct)
        {
            TvMazeProduct? product = await _productData.GetByIdProductAsync(IdProduct);
            if (product != null)
            {
                List<NodeList> nodes = await _nodeData.GetNodesListAsync(product.IdRoot.Value);
                return nodes;
            }
            return new List<NodeList>();
        }

        public async Task SetCacheFromApiService(int IdProduct)
        {
            TvMazeFetched tvMazeFetched = await _productService.FetchTvMazeAsync(IdProduct);
            if (tvMazeFetched != null)
            {
                TvMazeProduct product  = TvMazeProduct.Cast((TvMazeforProductTable)tvMazeFetched);

                product.Country = tvMazeFetched.Network.Country.Name;

                TvMaze tvMazeRoot =  TvMaze.Cast(tvMazeFetched);

                Node root = new Node()
                {
                    Name = product.Name,
                    IdTemplate = 11,//TvMaze
                    JsonValue = JsonConvert.SerializeObject(tvMazeRoot)
                };
                await _nodeData.InsertNodeAsync(root);
                if (root.Id != null)
                {
                    product.IdRoot = (int)root.Id;
                    await _productData.InsertAsync(product);

                    //Schedule
                    await InsertNodeANDRelation(product.IdRoot.Value, 8, product.Name, JsonConvert.SerializeObject(tvMazeFetched.Schedule), 1);
                    //Rating
                    await InsertNodeANDRelation(product.IdRoot.Value, 7, product.Name, JsonConvert.SerializeObject(tvMazeFetched.Rating), 2);
                    //NetWork
                    await InsertNodeNetWork(product.IdRoot.Value, tvMazeFetched.Network.Name, tvMazeFetched.Network);//3
                    //Externals
                    await InsertNodeANDRelation(product.IdRoot.Value, 3, product.Name, JsonConvert.SerializeObject(tvMazeFetched.Externals), 4);
                    //Image
                    await InsertNodeANDRelation(product.IdRoot.Value, 2, product.Name, JsonConvert.SerializeObject(tvMazeFetched.Image), 5);
                    //Link
                    await InsertNodeLink(product.IdRoot.Value, product.Name, tvMazeFetched._Links);//6

                }
                else
                {
                    throw new Exception($"Error en Guardado de Nodo del producto [{product.Id}]");
                }
            }
        }

        private async Task InsertNodeNetWork(int idRoot, string name, Network network)
        {
            var jsonObject = new { network.Id, network.Name, network.OfficialSite };
            Node networkNode = new Node()
            {
                Name = name,
                IdTemplate = 5,
                JsonValue = JsonConvert.SerializeObject(jsonObject)
            };
            await InsertLeaf(networkNode, idRoot, null, 3);

            Node countryNode = new Node()
            {
                Name = "Country-"+name,
                IdTemplate = 1,
                JsonValue = JsonConvert.SerializeObject(network.Country)
            };
            await InsertLeaf(countryNode, idRoot, networkNode.Id, 1);

        }

        private async Task InsertNodeLink(int idRoot, string name, Links links)
        {
            Node linkNode = new Node()
            {
                Name = name,
                IdTemplate = 4,
                JsonValue = String.Empty
            };
            await InsertLeaf(linkNode, idRoot, null, 6);
            int place = 1;
            if (links?.Self != null)
            {
                Node selfNode = new Node()
                {
                    Name = name,
                    IdTemplate = 9,
                    JsonValue = JsonConvert.SerializeObject(links.Self)
                };
                await InsertLeaf(selfNode, idRoot, linkNode.Id, place);
                place++;
            }
            if (links?.Previousepisode != null)
            {
                Node prevNode = new Node()
                {
                    Name = name,
                    IdTemplate = 6,
                    JsonValue = JsonConvert.SerializeObject(links.Previousepisode)
                };
                await InsertLeaf(prevNode, idRoot, linkNode.Id, place);
                place++;
            }
            if (links?.Nextepisode != null)
            {
                Node nextNode = new Node()
                {
                    Name = name,
                    IdTemplate = 10,
                    JsonValue = JsonConvert.SerializeObject(links.Nextepisode)
                };
                await InsertLeaf(nextNode, idRoot, linkNode.Id, place);
            }
        }

        private async Task InsertNodeANDRelation(int idRoot, int idTemplate, string name, String jsonValue, int place = 0)
        {
            Node element = new Node()
            {
                Name = name,
                IdTemplate = idTemplate,
                JsonValue = jsonValue
            };
            await InsertLeaf(element, idRoot, null, place);
        }

        private async Task InsertLeaf(Node element, int idRoot, int? idParent = null, int place = 1)
        {
            await _nodeData.InsertNodeAsync(element);
            NodeRelation relation = new NodeRelation();
            relation.IdNodeRoot = idRoot;
            relation.IdNodeParent = idParent ?? idRoot;
            relation.IdNode = (int)element.Id;
            relation.Place = place;
            await _nodeRelationData.InsertNodeRelationAsync(relation);
        }

    }
}