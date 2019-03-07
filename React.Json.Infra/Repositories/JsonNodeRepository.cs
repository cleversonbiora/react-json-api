using Dapper;
using System.Linq;
using React.Json.Domain.Models;
using React.Json.Domain.Repositories;
using System.Collections.Generic;

namespace React.Json.Infra.Repositories
{
    public partial class JsonNodeRepository : IJsonNodeRepository
    {
        public List<JsonNode> GetNodes(int Id)
        {
            using (var conn = ConnectionFactory.GetJsonOpenConnection())
            {
                return conn.Query<JsonNode>(SelectNodes, new { Id }).ToList();
            }
        }
    }
}
