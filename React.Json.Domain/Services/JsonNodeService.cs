using React.Json.Domain.Interfaces;
using React.Json.Domain.Models;
using React.Json.Domain.Repositories;
using System.Collections.Generic;

namespace React.Json.Domain.Services
{
    public class JsonNodeService : IJsonNodeService
    {
        private readonly IJsonNodeRepository _reposotory;

        public JsonNodeService(IJsonNodeRepository reposotory)
        {
            _reposotory = reposotory;
        }

        public List<JsonNode> GetNodes(int Id)
        {
            return _reposotory.GetNodes(Id);
        }
    }
}
