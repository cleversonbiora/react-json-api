using React.Json.Domain.Models;
using System.Collections.Generic;

namespace React.Json.Domain.Repositories
{
    public interface IJsonAttributeRepository
    {
        List<JsonAttribute> GetAttributes(int Id);
    }
}
