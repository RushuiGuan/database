using Albatross.Database;
using System.Data;
using System.Data.SqlClient;

namespace Albatross.Database.SqlServer {
	public class GetConnectionString : IGetConnectionString {
		public string Get(Database db) {

			SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
			if (string.IsNullOrEmpty(db.ConnectionString)) {
				sb.InitialCatalog = db.InitialCatalog;
				sb.DataSource = db.DataSource;
				if (db.SSPI) {
					sb.IntegratedSecurity = true;
				} else {
					sb.UserID = db.UserName;
					sb.Password = db.Password;
				}
				return sb.ToString();
			} else {
				return db.ConnectionString;
			}
		}
	}
}
