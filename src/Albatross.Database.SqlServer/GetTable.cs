using Albatross.Database;
using Dapper;

namespace Albatross.CodeGen.SqlServer {
	public class GetTable : IGetTable {
		IGetDbConnection getDbConnection;

		public GetTable(IGetDbConnection getDbConnection) {
			this.getDbConnection = getDbConnection;
		}

		public Table Get(Server server, string schema, string name) {
			using (var db = getDbConnection.Get(server)) {
				return db.QueryFirst<Table>(Get(schema, name));
			}
		}

		CommandDefinition Get(string schema, string name) {
			return new CommandDefinition(@"
select  
	TABLE_SCHEMA as [Schema], 
	TABLE_NAME as [Name] 
from INFORMATION_SCHEMA.TABLES 
where TABLE_NAME = @name", new { schema = schema, name = name});
		}
	}
}
