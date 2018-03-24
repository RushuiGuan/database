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
* Reference [Albatross.Database](xref:Albatross.Database) and [Albatross.Database.SqlServer](xref:Albatross.Database.SqlServer)
* An Ioc container is recommended.
	* If the project is using SimpleInjector for Ioc, Reference [Albatross.Database.Ioc.SimpleInjector](xref:Albatross.Database.Ioc.SimpleInjector) and use class [Albatross.Database.Ioc.SimpleInjector.SqlServerPackage](xref:Albatross.Database.Ioc.SimpleInjector.SqlServerPackage) to register the container correctly.
	* If another container is used, register the interface in the [Albatross.Database](xref:Albatross.Database) manually.  Reference class [Albatross.Database.Ioc.SimpleInjector.SqlServerPackage] if necessary.
	* If no container is used, use the static Create method of the [Factory](xref:Albatross.Database.Ioc.SimpleInjector.Factory) class to retrive the interfaces in [Albatross.Database](xref:Albatross.Database).