using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Database {
	/// <summary>
	/// Return all the index columns of a table index
	/// </summary>
	public interface IListTableIndexColumn {
		IEnumerable<IndexColumn> List(Index index);
	}
}
