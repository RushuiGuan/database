using System.Linq;
using Albatross.Database;
using Dapper;

namespace Albatross.Database.SqlServer {
	public class GetTable : IGetTable {
		IGetDbConnection getDbConnection;
		IListTableIndex listTableIndex;
		IListTableColumn listTableColumn;

		public GetTable(IGetDbConnection getDbConnection, IListTableColumn listTableColumn, IListTableIndex listTableIndex) {
			this.getDbConnection = getDbConnection;
			this.listTableIndex = listTableIndex;
			this.listTableColumn = listTableColumn;
		}

		public Table Get(Database database, string schema, string name) {
			Table table;
			using (var db = getDbConnection.Get(database)) {
				table = db.QueryFirst<Table>(Get(schema, name));
			}
			table.Database = database;
			table.Columns = listTableColumn.List(table);
			table.IdentityColumn = (from item in table.Columns where item.IsIdentity select item).FirstOrDefault();
			var indexes = listTableIndex.List(table);
			table.PrimaryKeys = (from index in indexes where index.IsPrimaryKey select index).FirstOrDefault()?.Columns;
			return table;
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
