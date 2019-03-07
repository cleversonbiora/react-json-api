using React.Json.Domain.Interfaces;
using React.Json.Domain.Models;
using React.Json.Domain.Repositories;
using System.Collections.Generic;

namespace React.Json.Domain.Services
{
    public class JsonAttributeService : IJsonAttributeService
    {
        private readonly IJsonAttributeRepository _reposotory;

        public JsonAttributeService(IJsonAttributeRepository reposotory)
        {
            _reposotory = reposotory;
        }

        public List<JsonAttribute> GetAttributes(int Id)
        {
            return _reposotory.GetAttributes(Id);
        }
    }
}
