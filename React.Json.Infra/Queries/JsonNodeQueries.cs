using System;
using System.Collections.Generic;
using System.Text;

namespace React.Json.Infra.Repositories
{
    public partial class JsonNodeRepository
    {
        #region [ Insert ]
        private const string InsertJson = @"";
        #endregion
        #region [ Select ]
        private const string SelectNodes = @"SELECT * FROM JsonNode where JsonAttributeId = @Id";
        #endregion
    }
}
