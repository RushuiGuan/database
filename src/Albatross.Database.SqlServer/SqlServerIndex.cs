using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database.SqlServer
{
    public class SqlServerIndex
    {
		public int object_id { get; set; }
		public string name    { get; set; }
		public int index_id { get; set; }
		public int type { get; set; }
		public string type_desc { get; set; }
		public bool is_unique { get; set; }
		public bool is_primary_key { get; set; }
		public bool is_unique_constraint { get; set; }
		public bool is_padded { get; set; }
		public bool is_disabled { get; set; }
		public bool is_hypothetical { get; set; }
		public bool allow_row_locks { get; set; }
		public bool allow_page_locks { get; set; }
		public bool has_filter { get; set; }
		public bool filter_definition { get; set; }
	}
}
