using Albatross.Database;
using Dapper;

namespace Albatross.CodeGen.SqlServer {
	public class GetTableIdentityColumn : IGetTableIdentityColumn {
		IGetDbConnection getDbConnection;
		IGetTable getTable;

		public GetTableIdentityColumn(IGetDbConnection getDbConnection, IGetTable getTable) {
			this.getDbConnection = getDbConnection;
			this.getTable = getTable;
		}

		public Column Get(Server server, string schema, string name) {
			Table table = getTable.Get(server, schema, name);
			using (var db = getDbConnection.Get(server)) {
				//return db.QueryFirst<Column>("select * from sys.columns where object_id = @id and is_identity = 1", new { id = table.Object_Id });
				return null;
			}
		}

		public Column Get(Table table) {
			throw new System.NotImplementedException();
		}
	}
}
