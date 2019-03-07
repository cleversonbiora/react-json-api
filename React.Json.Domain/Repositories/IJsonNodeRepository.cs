using React.Json.Domain.Models;
using System.Collections.Generic;

namespace React.Json.Domain.Repositories
{
    public interface IJsonNodeRepository
    {
        List<JsonNode> GetNodes(int Id);
    }
}
