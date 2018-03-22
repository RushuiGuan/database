using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database
{
    public class Procedure
    {
		public Database Database { get; set; }

		public string Name { get; set; }
		public string Schema{ get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }

		public IEnumerable<Parameter> Parameters { get; set; }
	}
}
