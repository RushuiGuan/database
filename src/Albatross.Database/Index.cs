using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database
{
    public class Index
    {
		public Table Table { get; set; }
		public string Name { get; set; }
		public bool IsUnique { get; set; }
		public bool IsPrimaryKey { get; set; }
		public IEnumerable<Column> Columns { get; set; }
	}
}
