using System;
using System.Collections.Generic;
using System.Text;

namespace React.Json.Infra.Repositories
{
    public partial class JsonAttributeRepository
    {
        #region [ Insert ]
        private const string InsertJson = @"";
        #endregion
        #region [ Select ]
        private const string SelectNodes = @"SELECT * FROM JsonAttribute where JsonNodeId = @Id";
        #endregion
    }
}
