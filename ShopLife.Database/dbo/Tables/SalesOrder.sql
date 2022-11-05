CREATE TABLE [dbo].[SalesOrder] (
    [Id] INT NOT NULL,
    CONSTRAINT [PK_SalesOrder] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'流水號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SalesOrder', @level2type = N'COLUMN', @level2name = N'Id';

