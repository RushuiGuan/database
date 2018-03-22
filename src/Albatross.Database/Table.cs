using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database
{
    public class Table {
		public Database Database { get; set; }
		public string Name { get; set; }
		public string Schema { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }

		public IEnumerable<Column> Columns { get; set; }
		public IEnumerable<IndexColumn> PrimaryKeys { get; set; }
		public Column IdentityColumn { get; set; }
	}
}
