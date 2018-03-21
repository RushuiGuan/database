using System.Linq;
using Albatross.CodeGen.SqlServer;
using Albatross.Database.SqlServer;
using NUnit.Framework;

namespace Albatross.Database.UnitTest {
	[TestFixture]
	public class GeneralUnitTest {
		public Database Database { get; private set; } = new Database {
			DataSource = ".",
			InitialCatalog = "master",
			SSPI = true,
		};

		public Database AlbatrossDb { get; private set; } = new Database {
			DataSource = ".",
			InitialCatalog = "albatross",
			SSPI = true,
		};




		[TestOf(typeof(GetConnectionString))]
		[TestCase("localhost", "content", true, null, null, ExpectedResult = "Data Source=localhost;Initial Catalog=content;Integrated Security=True")]
		[TestCase("localhost", "content", false, "jdoe", "welcome", ExpectedResult = "Data Source=localhost;Initial Catalog=content;User ID=jdoe;Password=welcome")]
		public string GetConnectionStringTest(string server, string database, bool sspi, string username, string pwd) {
			string data = new GetConnectionString().Get(new Database {
				DataSource = server,
				InitialCatalog = database,
				SSPI = sspi,
				UserName = username,
				Password = pwd,
			});
			return data;
		}

		[TestOf(typeof(GetSqlType))]
		[TestCase("int", ExpectedResult = "int")]
		[TestCase("bigint", ExpectedResult = "bigint")]
		public string GetSqlTypeTest(string name) {
			GetSqlType getSqlType = new GetSqlType(new GetDbConnection(new GetConnectionString()));
			var type = getSqlType.Get(Database, null, name);
			return type.Name;
		}

		[Test(TestOf =typeof(ListSqlType))]
		public void ListSqlTypeTest() {
			ListSqlType listSqlType = new ListSqlType(new GetDbConnection(new GetConnectionString()));
			var types = listSqlType.List(Database);
			Assert.Greater(types.Count(), 0);
		}

		[TestOf(typeof(GetTable))]
		[TestCase("dbo", "spt_fallback_db", ExpectedResult = "spt_fallback_db")]
		public string GetTableTest(string schema, string name) {
			GetTable getTable = new GetTable(new GetDbConnection(new GetConnectionString()));
			var type = getTable.Get(Database, schema, name);
			return type.Name;
		}

		[TestOf(typeof(ListTableIndex))]
		[TestCase("dbo", "trade")]
		public void GetTableIndexTest(string schema, string name) {
			Table table = new Table {
				Database = AlbatrossDb,
				Schema = schema,
				Name = name,
			};
			var getDb = new GetDbConnection(new GetConnectionString());
			ListTableIndex getTableIndex = new ListTableIndex(getDb, new ListTableIndexColumn(getDb));
			var indexes = getTableIndex.List(table);
			Assert.NotZero(indexes.Count());
			foreach (var item in indexes) {
				Assert.NotZero(item.Columns.Count());
			}
		}
	}
}
