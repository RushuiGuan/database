using Albatross.Database.SqlServer;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Albatross.Database.Ioc.SimpleInjector {
	/// <summary>
	/// This class will set the <see href="https://github.com/simpleinjector/SimpleInjector">SimpleInjector</see>'s container between the interfaces in the <see cref="Albatross.Database"/> namespace and the implementations in the <see cref="Albatross.Database.SqlServer"/> namespace.
	/// </summary>
	public class SqlServerPackage : IPackage {
		public void RegisterServices(Container container) {
			container.Register<IGetConnectionString, GetConnectionString>(Lifestyle.Singleton);
			container.Register<IGetDbConnection, GetDbConnection>(Lifestyle.Singleton);
			container.Register<IGetProcedure, GetProcedure>(Lifestyle.Singleton);
			container.Register<IGetSqlType, GetSqlType>(Lifestyle.Singleton);
			container.Register<IGetTable, GetTable>(Lifestyle.Singleton);
			container.Register<IGetView, GetView>(Lifestyle.Singleton);
			container.Register<IGetTableColumnType, GetTableColumnType>(Lifestyle.Singleton);
			container.Register<IListProcedureParameter, ListProcedureParameter>(Lifestyle.Singleton);

			container.Register<IListSqlType, ListSqlType>(Lifestyle.Singleton);
			container.Register<IListTableColumn, ListTableColumn>(Lifestyle.Singleton);
			container.Register<IListTableIndex, ListTableIndex>(Lifestyle.Singleton);
			container.Register<IListTableIndexColumn, ListTableIndexColumn>(Lifestyle.Singleton);

		}
	}
}
