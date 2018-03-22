using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database.SqlServer
{
	public class GetProcedure : IGetProcedure {
		IGetDbConnection getDbConnection;
		IListProcedureParameter listProcedureParameter;

		public GetProcedure(IGetDbConnection getDbConnection, IListProcedureParameter listProcedureParameter) {
			this.getDbConnection = getDbConnection;
			this.listProcedureParameter = listProcedureParameter;
		}

		public Procedure Get(Database database, string schema, string name) {
			Procedure procedure;
			using (var db = getDbConnection.Get(database)) {
				procedure = db.QueryFirst<Procedure>(GetCommandDefinition(schema, name));
			}
			procedure.Parameters = listProcedureParameter.List(procedure);
			return procedure;
		}

		CommandDefinition GetCommandDefinition(string schema, string name) {
			return new CommandDefinition(@"
select 
	SPECIFIC_SCHEMA as [Schema],
	SPECIFIC_NAME as [Name],
	CREATED,
	LAST_ALTERED AS Modified
from INFORMATION_SCHEMA.ROUTINES 
where ROUTINE_TYPE = 'procedure' and SPECIFIC_SCHEMA = @schema and SPECIFIC_NAME = @name;
", new { schema = schema, name = name, });
		}
	}
}
