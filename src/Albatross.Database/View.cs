using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database
{
    public class View
    {
		public Database Database { get; set; }
		public string Name { get; set; }
		public string Schema { get; set; }

		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
}
