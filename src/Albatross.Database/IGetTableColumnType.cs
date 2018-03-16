using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database
{
    public interface IGetTableColumnType
    {
		SqlType Get(Table table, string column);
	}
}
