using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database {
	/// <summary>
	/// The class represents a database data type
	/// </summary>
	public class SqlType {
		public string Schema { get; set; }
		public string Name { get; set; }
		public int MaxLength { get; set; }
		public int Precision { get; set; }
		public int Scale { get; set; }
		public bool IsNullable { get; set; }
		public bool IsUserDefined { get; set; }
		public bool IsTableType { get; set; }
	}
}
