CREATE TABLE [dbo].[Delete] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [OtherInfo] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Delete] PRIMARY KEY CLUSTERED ([Id] ASC)
);

