using React.Json.CrossCutting.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace React.Json.Domain.Models
{
    public class JsonAttribute
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public int JsonNodeId { get; set; }
        public JsonType Type { get; set; }
    }
}
