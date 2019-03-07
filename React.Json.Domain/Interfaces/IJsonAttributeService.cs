using React.Json.Domain.Models;
using System.Collections.Generic;

namespace React.Json.Domain.Interfaces
{
    public interface IJsonAttributeService
    {
        List<JsonAttribute> GetAttributes(int Id);
    }
}
