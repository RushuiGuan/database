﻿using System.Linq;
using Albatross.Database.SqlServer;
using NUnit.Framework;
using SimpleInjector;

namespace Albatross.Database.UnitTest {
	[TestFixture]
	public class GeneralUnitTest {
		Container Container { get; } = new Container();

		GetDbConnection GetDbConnection { get; } = new GetDbConnection(new GetConnectionString());

		public Database MasterDb { get; private set; } = new Database {
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
			GetSqlType getSqlType = new GetSqlType(GetDbConnection);
			var type = getSqlType.Get(MasterDb, null, name);
			return type.Name;
		}

		[Test(TestOf =typeof(ListSqlType))]
		public void ListSqlTypeTest() {
			ListSqlType listSqlType = new ListSqlType(GetDbConnection);
			var types = listSqlType.List(MasterDb);
			Assert.Greater(types.Count(), 0);
		}

		[TestOf(typeof(GetTable))]
		//[TestCase("dbo", "spt_fallback_db", ExpectedResult = "spt_fallback_db")]
		[TestCase("dyn", "svc", ExpectedResult = "svc")]
		public string GetTableTest(string schema, string name) {
			GetTable getTable = new GetTable(GetDbConnection, new ListTableColumn(GetDbConnection, new GetTableColumnType(GetDbConnection)), new ListTableIndex(GetDbConnection, new ListTableIndexColumn(GetDbConnection)));
			var type = getTable.Get(AlbatrossDb, schema, name);
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
			ListTableIndex getTableIndex = new ListTableIndex(GetDbConnection, new ListTableIndexColumn(GetDbConnection));
			var indexes = getTableIndex.List(table);
			Assert.NotZero(indexes.Count());
			foreach (var item in indexes) {
				Assert.NotZero(item.Columns.Count());
			}
		}
	}
}
