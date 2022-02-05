CREATE TABLE [dbo].[CarImages] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [CarId] INT NULL,
    [ImagePath]  NVARCHAR (100) NULL,
    [Date]      DATETIME      NULL,
    CONSTRAINT [PK_CarImages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CarImages_Car] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Car] ([Id])
    );