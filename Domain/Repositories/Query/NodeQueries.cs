namespace Doselete.Domain.Repository.Query
{
    class NodeQueries
    {
        public const string GetNodeRoot = @"
            SELECT node.*, template.name AS NameTemplate
            FROM node
            INNER JOIN template on template.IdTemplate = node.IdTemplate
            WHERE Not Exists(Select IdNode from node_relation WHERE node_relation.IdNode = node.IdNode)
            ORDER BY Modify DESC";
        public const string GetNode = "SELECT * FROM node WHERE IdNode =  @IdNode";
        public const string GetNodeByIdNodeRoot = "SELECT * FROM node WHERE IdNodeRoot =  @IdNodeRoot";
        public const string InsertNode = @"
        INSERT INTO node ( Name, JsonValue, IdTemplate, Modify)
        VALUES ( @Name, @JsonValue, @IdTemplate, CURRENT_DATE());
        SELECT LAST_INSERT_ID();";
        //"SELECT IdNode FROM node ORDER BY IdNode DESC LIMIT 1;"

        public const string UpdateNode = @"
        UPDATE node 
            SET Name = @Name, JsonValue = @JsonValue, IdTemplate = @IdTemplate, `Modify` = CURRENT_DATE()
        WHERE IdNode = @IdNode;";
        public const string DeleteNode = @"DELETE FROM node  WHERE IdNode = @IdNode;";
        public const string DeleteNodes = @"DELETE FROM node  WHERE IdNode in @IdNodes;";
        public const string GetNodesListByIdNodeRoot = @"
        SELECT node.*, template.Name AS NameTemplate,template.AttributeName AS JsonName, node_relation.IdNodeParent, IFNULL(node_relation.Place,0) AS `Order`
        FROM node
        INNER JOIN template ON template.Id = node.IdTemplate
        LEFT JOIN node_relation ON node_relation.IdNode = node.Id
        WHERE @IdNode IN (node.Id,node_relation.IdNodeRoot)
        ORDER BY node.Id;";
    }
}