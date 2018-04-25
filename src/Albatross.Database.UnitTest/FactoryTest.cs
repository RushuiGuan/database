using Albatross.Database.SqlServer.SimpleInjector;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Database.UnitTest
{
	[TestFixture]
    public class FactoryTest
    {
		[Test(TestOf = typeof(Factory))]
		public void GetInterfaces() {
			Database db = new Database {
				DataSource = "localhost",
				InitialCatalog = "master",
				SSPI = true,
			};
			var handle = Albatross.Database.SqlServer.SimpleInjector.Factory.Create<Albatross.Database.IGetTable>();
			Table table = handle.Get(db, "dbo", "spt_monitor");
		}
    }
}
