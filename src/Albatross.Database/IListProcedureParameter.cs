using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database
{
    public interface IListProcedureParameter
    {
		IEnumerable<Variable> List(Procedure procedure);
    }
}
