using System.Data.Common;
using System.Data.SqlClient;
using React.Json.CrossCutting;

namespace React.Json.Infra
{
    public class ConnectionFactory
    {
        public static DbConnection GetJsonOpenConnection()
        {
            var connection = new SqlConnection(ConnectionStrings.JsonConnection);

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            return connection;
        }
    }
}
