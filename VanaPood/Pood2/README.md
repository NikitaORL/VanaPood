CREATE TABLE [dbo].[ToodeTabel] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Toodenimetus] VARCHAR (50)    NOT NULL,
    [Kogus]        INT             NOT NULL,
    [Hind]         FLOAT (53)      NOT NULL,
    [Pilt]         TEXT            NULL,
    [BPilt]        VARBINARY (MAX) NULL,
    [Kategooriad]  INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



CREATE TABLE [dbo].[KategooriaTabel] (
    [Id]                 INT          IDENTITY (1, 1) NOT NULL,
    [Kategooria_nimetus] VARCHAR (50) NOT NULL,
    [Kirjendus]          TEXT         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

