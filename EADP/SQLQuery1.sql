CREATE TABLE [dbo].[Student] (
  [Student_Admin] VARCHAR (12) NOT NULL PRIMARY KEY,
  [Student_name] VARCHAR (60) NOT NULL,
  [Email] VARCHAR (60) NOT NULL,
  [Password] BINARY(64) NOT NULL,
  [School] VARCHAR (12) NOT NULL,
  [Gender] char(1) NOT NULL,
  [DOB] DATE NOT NULL,
  [PEM Group] VARCHAR (12) NOT NULL,

);


