using System.Linq;
using Albatross.CodeGen.SqlServer;
using Albatross.Database.SqlServer;
using NUnit.Framework;

namespace Albatross.Database.UnitTest {
	[TestFixture]
	public class GeneralUnitTest {

		[TestOf(typeof(GetConnectionString))]
		[TestCase("localhost", "content", true, null, null, ExpectedResult = "Data Source=localhost;Initial Catalog=content;Integrated Security=True")]
		[TestCase("localhost", "content", false, "jdoe", "welcome", ExpectedResult = "Data Source=localhost;Initial Catalog=content;User ID=jdoe;Password=welcome")]
		public string GetConnectionStringTest(string server, string database, bool sspi, string username, string pwd) {
			string data = new GetConnectionString().Get(new Server {
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
			Server server = new Server { DataSource = ".", InitialCatalog = "master", SSPI = true, };
			var type = getSqlType.Get(server, name);
			return type.Name;
		}

		[Test(TestOf =typeof(ListSqlType))]
		public void ListSqlTypeTest() {
			ListSqlType listSqlType = new ListSqlType(new GetDbConnection(new GetConnectionString()));
			Server server = new Server { DataSource = ".", InitialCatalog = "master", SSPI = true, };
			var types = listSqlType.List(server);
			Assert.Greater(types.Count(), 0);
		}
	}
}
