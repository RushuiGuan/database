using Albatross.Database.SqlServer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Database.UnitTest {
	[TestFixture(TestOf = typeof(ParseCriteria))]
	public class ParseCriteriaTest {



		[TestCase(null, ExpectedResult = null)]
		[TestCase("", ExpectedResult = null)]
		[TestCase("test", ExpectedResult = null)]
		[TestCase("a.b", ExpectedResult = "a")]
		[TestCase("a.*", ExpectedResult = "a")]
		[TestCase("*.*", ExpectedResult = null)]
		[TestCase("*a.*", ExpectedResult = "%a")]
		[TestCase("*a*b*.*", ExpectedResult = "%a%b%")]
		public string SchemaCheck(string criteria) {
			string schema, name;
			new ParseCriteria().Parse(criteria, out schema, out name);
			return schema;
		}

		[TestCase(null, ExpectedResult = null)]
		[TestCase("", ExpectedResult = null)]
		[TestCase("test", ExpectedResult = "test")]
		[TestCase("a.b", ExpectedResult = "b")]
		[TestCase("a.*", ExpectedResult = null)]
		[TestCase("a.b*", ExpectedResult = "b%")]
		[TestCase("*", ExpectedResult = null)]
		[TestCase("*.*", ExpectedResult = null)]
		public string NameCheck(string criteria) {
			string schema, name;
			new ParseCriteria().Parse(criteria, out schema, out name);
			return name;
		}
	}
}
