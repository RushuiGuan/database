using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Database
{
    public interface IGetTablePrimaryKey {
		IEnumerable<Column> Get(Table table);
    }
}
