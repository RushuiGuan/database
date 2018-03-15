using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database.SqlServer
{
	public class ListSqlType : IListSqlType {
		IGetDbConnection getDbConnection;

		public ListSqlType(IGetDbConnection getDbConnection) {
			this.getDbConnection = getDbConnection;
		}


		public IEnumerable<SqlType> List(Server server) {
			using (var db = getDbConnection.Get(server)) {
				return db.Query<SqlType>(GetCommand());
			}
		}

		CommandDefinition GetCommand() {
			return new CommandDefinition(@"
select 
	Name, 
	max_length as MaxLength, 
	Precision,
	Scale,
	is_nullable as IsNullable,
	is_user_defined as IsUserDefined,
	is_table_type as IsTableType
from sys.types");
		}
	}
}
