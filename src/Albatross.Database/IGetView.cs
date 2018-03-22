using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database
{
    public interface IGetView {
		View Get(Database database, string schema, string name);
    }
}
