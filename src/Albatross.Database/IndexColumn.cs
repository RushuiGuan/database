using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database
{
    public class IndexColumn
    {
		public string Name { get; set; }
		public int KeyOrdinal { get; set; }
		public bool IsDescending { get; set; }
	}
}
