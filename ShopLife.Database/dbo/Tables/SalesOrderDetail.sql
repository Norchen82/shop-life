CREATE TABLE [dbo].[SalesOrderDetail] (
    [Id] INT NOT NULL,
    CONSTRAINT [PK_SalesOrderDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'流水號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SalesOrderDetail', @level2type = N'COLUMN', @level2name = N'Id';

