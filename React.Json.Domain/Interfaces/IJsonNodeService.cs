using React.Json.Domain.Models;
using System.Collections.Generic;

namespace React.Json.Domain.Interfaces
{
    public interface IJsonNodeService
    {
        List<JsonNode> GetNodes(int Id);
    }
}
