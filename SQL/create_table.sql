Use HelloWorld
GO

if not exists (select * from sys.objects where name='phrases')
    create table HelloWorldSchema.phrases (
		id int primary key identity,
        body text not null,
    )
go