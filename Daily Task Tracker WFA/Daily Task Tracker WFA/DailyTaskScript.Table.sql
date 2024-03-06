CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY,
	ApplicationName varchar(50),
	StartTime varchar(50),
	ExitTime varchar(50),
	UserInteractionTime numeric(30,2),
	TotalProcessTime numeric(30,2)
)
