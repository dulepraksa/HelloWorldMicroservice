IF(NOT EXISTS (SELECT name
FROM master.dbo.sysdatabases
WHERE ( name = N'HelloWorld')))
	
	Create database HelloWorld;