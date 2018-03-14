using Albatross.Database;
using System.Data;
using System.Data.SqlClient;

namespace Albatross.CodeGen.SqlServer {
	public class GetConnectionString : IGetConnectionString {
		public string Get(Server server) {

			SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
			if (string.IsNullOrEmpty(server.ConnectionString)) {
				sb.InitialCatalog = server.InitialCatalog;
				sb.DataSource = server.DataSource;
				if (server.SSPI) {
					sb.IntegratedSecurity = true;
				} else {
					sb.UserID = server.UserName;
					sb.Password = server.Password;
				}
				return sb.ToString();
			} else {
				return server.ConnectionString;
			}
		}
	}
}
