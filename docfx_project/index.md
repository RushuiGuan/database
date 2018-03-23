# Albatross Database Schema Api

## Summary
A set of C# APIs that can read database schema metadata.

## Description
This repo contains a set of projects that reads metadata from a database server.  It defines C# objects that map to database objects such as table, view, stored procedure etc.  It also contains interfaces and implementations to retrieve those objects from the database.  For example, [IListTableColumn](xref:Albatross.Database.IListTableColumn) will return all [Column](xref:Albatross.Database.Column) defined by a database table.  [IListProcedureParameter](xref:Albatross.Database.IListProcedureParameter) will return all parameters defined by a stored procedure.

# Projects

* [Albatross.Database](xref:Albatross.Database) - Class and interface definition
* [Albatross.Database.SqlServer](xref:Albatross.Database.SqlServer) - Sql server implementation
* [Albatross.Database.Ioc.SimpleInjector](xref:Albatross.Database.Ioc.SimpleInjector) - Ioc using SimpleInjector
* [Albatross.Database.UnitTest](xref:Albatross.Database.UnitTest) - Unit test using NUnit

# How to use the Api
The interfaces of the Api are defined in project [Albatross.Database](xref:Albatross.Database) and the project [Albatross.Database.SqlServer](xref:Albatross.Database.SqlServer) contains the implementation for SQL server.  Ioc container is strongly recomended when using this Api.  If the SimpleInjector container is being used, use Nuget to reference the [Albatross.Database.Ioc.SimpleInjector](xref:Albatross.Database.Ioc.SimpleInjector) assembly.  The nuget package will pull down both [Albatross.Database](xref:Albatross.Database) assembly and [Albatross.Database.SqlServer](xref:Albatross.Database.SqlServer) assembly.  The [Albatross.Database.Ioc.SimpleInjector.SqlServerPackage](xref:Albatross.Database.Ioc.SimpleInjector.SqlServerPackage) class can register the container correctly.  If another container is being used, nuget both [Albatross.Database](xref:Albatross.Database) and  [Albatross.Database.SqlServer](xref:Albatross.Database.SqlServer) and use the chosen container to register the interfaces correctly.  Reference the [Albatross.Database.Ioc.SimpleInjector.SqlServerPackage](xref:Albatross.Database.Ioc.SimpleInjector.SqlServerPackage) class if necessary.