using System.Collections.Generic;
using Albatross.Database;
using Dapper;

namespace Albatross.CodeGen.SqlServer {
	public class GetTableColumn : IGetTableColumn {
		IGetDbConnection getDbConnection;
		IGetTable getTable;

		public GetTableColumn(IGetDbConnection getDbConnection, IGetTable getTable) {
			this.getDbConnection = getDbConnection;
			this.getTable = getTable;
		}

		public IEnumerable<Column> Get(Server server, string schema, string name) {
			Table table = getTable.Get(server, schema, name);
			using (var db = getDbConnection.Get(server)) {
				//return db.Query<Column>("select * from sys.columns where object_id = @id", new { id = table.Object_Id });
				return null;
			}
		}

		public IEnumerable<Column> Get(Table table) {
			throw new System.NotImplementedException();
		}
	}
}
