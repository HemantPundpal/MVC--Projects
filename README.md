# MVC--Projects
Introduction to MVC

The Solution is clean (no executables) and the packages folder is deleted before project is uploaded, this is to reduce the number of files. So, make sure REBUILD ALL is issued a few time before running the programs to regenerate the package folder according to dependencies and create the executables.
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

