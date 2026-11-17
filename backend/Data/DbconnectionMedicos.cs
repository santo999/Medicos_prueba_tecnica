using Microsoft.Data.SqlClient;

namespace backend.Data
{
    public class DbconnectionMedicos(IConfiguration configuration)
    {

        private readonly string connectionString = configuration.GetConnectionString("DefaulConnection") ?? "";

        public SqlConnection CreateConnection() => new SqlConnection(connectionString);

    }
}
