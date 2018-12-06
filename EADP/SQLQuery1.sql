

CREATE TABLE [dbo].[Feedback] (
    [FeedbackID]    INT            NOT NULL,
    [ProgCode]      INT            NOT NULL,
    [Student_Admin] VARCHAR (12)            NOT NULL,
    [Rate]          TINYINT        NOT NULL,
    [Recommends]    NVARCHAR (MAX) NOT NULL,
    [Comments]      NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([FeedbackID] ASC),
    CONSTRAINT [FK_Feedback_Trip] FOREIGN KEY ([ProgCode]) REFERENCES [dbo].[Trip] ([ProgCode]),
    CONSTRAINT [FK_Feedback_Student] FOREIGN KEY ([Student_Admin]) REFERENCES [dbo].[Student] ([Student_Admin])
);