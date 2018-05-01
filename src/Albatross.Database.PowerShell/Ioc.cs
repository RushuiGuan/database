using SimpleInjector;
using System;

namespace Albatross.Database.PowerShell {
	public class Ioc {
		Container container = new Container();
		private Ioc() {
			new Albatross.Database.SqlServer.SimpleInjector.Pack().RegisterServices(container);
			container.Verify();
		}





		static Lazy<Ioc> lazy = new Lazy<Ioc>(() => new Ioc());
		public static T Get<T>() where T : class {
			return lazy.Value.container.GetInstance<T>();
		}
	}
}