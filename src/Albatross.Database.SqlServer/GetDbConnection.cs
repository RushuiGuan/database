using Albatross.Database;
using System.Data;
using System.Data.SqlClient;

namespace Albatross.Database.SqlServer {
	public class GetDbConnection : IGetDbConnection {
		IGetConnectionString getConnectionString;

		public GetDbConnection(IGetConnectionString getConnectionString) {
			this.getConnectionString = getConnectionString;
		}

		public IDbConnection Get(Database database) {
			string connectionString = getConnectionString.Get(database);
			return new SqlConnection(connectionString);
		}
	}
}
