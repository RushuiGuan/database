using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database.SqlServer
{
	public class GetSqlType : IGetSqlType {
		IGetDbConnection getDbConnection;

		public GetSqlType(IGetDbConnection getDbConnection) {
			this.getDbConnection = getDbConnection;
		}


		public SqlType Get(Server server, string name) {
			using (var db = getDbConnection.Get(server)) {
				return db.QueryFirst<SqlType>(GetCommand(name));
			}
		}

		CommandDefinition GetCommand(string name) {
			return new CommandDefinition(@"
select 
	Name, 
	max_length as MaxLength, 
	Precision,
	Scale,
	is_nullable as IsNullable,
	is_user_defined as IsUserDefined,
	is_table_type as IsTableType
from sys.types where name = @name;
", new { name = name, });
		}
	}
}
