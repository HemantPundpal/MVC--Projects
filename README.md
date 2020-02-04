# MVC--Projects
Introduction to MVC
I clean and deleted the packages folder before I upload the project, to reduce the numbe of files. So, make sure REBUILD ALL is issued a few time before running the programs.
- Following Database tables are used through out the example projects in Introduction to ADO.NET


CREATE TABLE [Students]

(

[Id] INT IDENTITY NOT NULL,

[FirstName] NVARCHAR(100) NOT NULL,

[LastName] NVARCHAR(100) NOT NULL,

CONSTRAINT [PK_Students] PRIMARY KEY ([Id])

)

CREATE TABLE [Emails]

(

[Id] INT IDENTITY NOT NULL,

[Email] NVARCHAR(100) NOT NULL,

[StudentId] INT NOT NULL,

CONSTRAINT [PK_Emails] PRIMARY KEY ([Id]),

CONSTRAINT [FK_Students_Emails] FOREIGN KEY ([StudentId]) REFERENCES [Students] ([Id]),

)

