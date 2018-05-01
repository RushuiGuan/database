using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database.SqlServer
{
	public class ParseCriteria : IParseCriteria {
		public void Parse(string criteria, out string schema, out string name) {
			schema = null;
			name = null;
			if (!string.IsNullOrEmpty(criteria)) {
				int index = criteria.IndexOf('.');
				if (index == -1) {
					name = criteria;
				} else {
					schema = criteria.Substring(0, index);
					name = criteria.Substring(index + 1);
				}
			}
		}
	}
}
