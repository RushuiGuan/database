# Albatross Database Schema Api

## Summary
A set of C# APIs that can read database schema metadata.

## Description
This repo contains a set of projects that reads metadata from a database server.  It defines C# objects that map to database objects such as table, view, stored procedure etc.  It also contains interfaces and implementations to retrieve those objects from the database.  For example, [IListTableColumn](xref:Albatross.Database.IListTableColumn) will return all [Column](xref:Albatross.Database.Column) defined by a database table.  [IListProcedureParameter](xref:Albatross.Database.IListProcedureParameter) will return all parameters defined by a stored procedure.

## Projects
* [Albatross.Database](xref:Albatross.Database) - Class and interface definition
* [Albatross.Database.SqlServer](xref:Albatross.Database.SqlServer) - Sql server implementation
* [Albatross.Database.SqlServer.SimpleInjector](xref:Albatross.Database.SqlServer.SimpleInjector) - Ioc using SimpleInjector
* [Albatross.Database.UnitTest](xref:Albatross.Database.UnitTest) - Unit test using NUnit

## Release
* 1.1.7 - Reduce the .Net Framework requirement from n462 to net46.  Make all three assemblies the same version.
* 1.1.6 - Albatross.Database.SqlServer; Albatross.Database.SqlServer.SimpleInjector
	* Update the implementation of [ParseCriteria](xref:Albatross.Database.SqlServer.ParseCriteria)
* 1.1.5
	* Has to make a new release since nuget doesn't allow any changes to project site url, release note or license file url.
* 1.1.4
	* New interface [IGetProcedure](xref:Albatross.Database.IGetProcedure)
		* Return the metadata about a stored procedure
		* Its implementation is [GetProcedure](xref:Albatross.Database.SqlServer.GetProcedure)
	* New interface [IGetProcedureDefinition](xref:Albatross.Database.IGetProcedureDefinition)
		* Return the text of a stored procedure
		* Its implementation is [GetProcedureDefinition](xref:Albatross.Database.SqlServer.GetProcedure)
	* Breaking Changes
		* Project Albatross.Database.Ioc.SimpleInjector is renamed to Albatross.Database.SqlServer.SimpleInjector
* 1.0.2 - Initial Release