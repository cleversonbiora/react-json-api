using Dapper;
using React.Json.Domain.Models;
using React.Json.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace React.Json.Infra.Repositories
{
    public partial class JsonAttributeRepository : IJsonAttributeRepository
    {
        public List<JsonAttribute> GetAttributes(int Id)
        {
            using (var conn = ConnectionFactory.GetJsonOpenConnection())
            {
                return conn.Query<JsonAttribute>(SelectNodes, new { Id }).ToList();
            }
        }
    }
}
