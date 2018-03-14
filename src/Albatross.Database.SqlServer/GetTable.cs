using Albatross.Database;
using Dapper;

namespace Albatross.CodeGen.SqlServer {
	public class GetTable : IGetTable {
		IGetDbConnection getDbConnection;

		public GetTable(IGetDbConnection getDbConnection) {
			this.getDbConnection = getDbConnection;
		}


		public Table Get(Server server, string schema, string name) {
			//using (var db = getDbConnection.Get(server)) {
			//	return db.QueryFirst<Table>("select * from sys.tables where name = @name and schema_id = @schema", new { name = name, schema = schemaObject.Schema_Id });
			//}
			return null;
		}
	}
}
