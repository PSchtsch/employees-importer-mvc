CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PayrollNumber] NVARCHAR(50) NOT NULL UNIQUE, 
    [Forename] NVARCHAR(50) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [Telephone] VARCHAR(15) NOT NULL, 
    [Mobile] VARCHAR(15) NOT NULL, 
    [Address] NVARCHAR(150) NOT NULL, 
    [Address2] NVARCHAR(150) NOT NULL, 
    [Postcode] VARCHAR(15) NOT NULL, 
    [EMailHome] NVARCHAR(320) NOT NULL, 
    [StartDate] DATE NOT NULL
)
