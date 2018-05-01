using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Database.PowerShell
{
    public class AssemblyRediret {
		public AssemblyRediret() {
			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
		}
		private static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
			var name = new AssemblyName(args.Name);
			if (string.Equals(name.Name, "SimpleInjector", StringComparison.InvariantCultureIgnoreCase)) {
				AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
				return typeof(Container).Assembly;
			}
			return null;
		}
	}
}
