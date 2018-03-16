using Albatross.Database;
using System.Data;
using System.Data.SqlClient;

namespace Albatross.CodeGen.SqlServer {
	public class GetDbConnection : IGetDbConnection {
		IGetConnectionString getConnectionString;

		public GetDbConnection(IGetConnectionString getConnectionString) {
			this.getConnectionString = getConnectionString;
		}

		public IDbConnection Get(Database.Database server) {
			string connectionString = getConnectionString.Get(server);
			return new SqlConnection(connectionString);
		}
	}
}
