using Albatross.Database.SqlServer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Database.UnitTest {
	[TestFixture(TestOf = typeof(GetProcedureDefinition))]
	public class GetProcedureDefinitionTest {

		[TestCase("ac.createcompany")]
		public void Run(string name) {
		}
	}
}
