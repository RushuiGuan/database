using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Database {
	public interface IListTableIndex {
		IEnumerable<Index> List(Table table);
	}
}
