USE HelloWorld
GO
if not exists(Select * from sys.schemas WHERE name = 'HelloWorldSchema') 
Begin
EXEC ('CREATE SCHEMA HelloWorldSchema AUTHORIZATION [dbo]')
end