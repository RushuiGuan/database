using SimpleInjector;
using System;

namespace Albatross.Database.PowerShell {
	public class Ioc {
		Container container = new Container();

		private Container Setup() {
			new Albatross.Database.SqlServer.SimpleInjector.Pack().RegisterServices(container);
			container.Verify();
			return container;
		}

		static Lazy<Container> lazy = new Lazy<Container>(() => new Ioc().Setup());
		public static Container Container { get { return lazy.Value; } }
		public static T Get<T>() where T:class{
			return lazy.Value.GetInstance<T>();
		}
	}
}
