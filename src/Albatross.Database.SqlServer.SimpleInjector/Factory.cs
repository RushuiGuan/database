using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database.SqlServer.SimpleInjector {
	public class Factory {
		Container container = new Container();
		private Factory() {
			new Pack().RegisterServices(container);
		}

		#region singleton
		private static readonly Lazy<Factory> lazy = new Lazy<Factory>(() => new Factory());
		public static Factory Instance { get { return lazy.Value; } }
		public static T Create<T>() where T:class{
			return Instance.container.GetInstance<T>();
		}
		#endregion
	}
}
