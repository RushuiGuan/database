using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.PowerShell {
	public partial class Ioc {
		private Ioc() {
			new Albatross.Database.SqlServer.SimpleInjector.Pack().RegisterServices(container);
			container.Verify();
		}
	}
}
