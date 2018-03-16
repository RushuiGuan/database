using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database
{
    public interface IListSqlType {
		IEnumerable<SqlType> List(Database database);
    }
}
