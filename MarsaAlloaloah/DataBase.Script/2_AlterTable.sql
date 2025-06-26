alter table Income
Add Date DateTime;

alter table Expenses
Add Date DateTime;

alter table Income
alter column Description nvarchar(500);

alter table Treasury
Add UserID int;
--Add foreign key
Alter table Treasury ADD CONSTRAINT FK_UserID FOREIGN KEY (UserID) REFERENCES Users(ID); 

--alter table treasuryTransactions
--add TreasuryID int;
----Add foreign key
--Alter table treasuryTransactions ADD CONSTRAINT FK_TreasuryID FOREIGN KEY (TreasuryID) REFERENCES Treasury(ID); 

USE [MarsaKAnzAbhar]
GO

/****** Object:  Table [dbo].[TreasuryTransactions]    Script Date: 06/26/2020 16:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TreasuryTransactions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TransfertAmount] [decimal](18, 2) NULL,
	[TreasuryID] [int] NULL,
 CONSTRAINT [PK_TreasuryTransactions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TreasuryTransactions]  WITH CHECK ADD  CONSTRAINT [FK_TreasuryID] FOREIGN KEY([TreasuryID])
REFERENCES [dbo].[Treasury] ([ID])
GO

ALTER TABLE [dbo].[TreasuryTransactions] CHECK CONSTRAINT [FK_TreasuryID]
GO


---------------------------------


alter table BankAccountTransactions
add BankID int;
--Add foreign key
Alter table BankAccountTransactions ADD CONSTRAINT FK_BankID FOREIGN KEY (BankID) REFERENCES BankAccounts(ID); 

-------------------------
/* Pour éviter les problèmes éventuels de perte de données, passez attentivement ce script en revue avant de l'exécuter en dehors du contexte du Concepteur de bases de données.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.BankAccountTransactions
	DROP CONSTRAINT FK_BankID
GO
ALTER TABLE dbo.BankAccounts SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_BankAccountTransactions
	(
	ID int NOT NULL IDENTITY (1, 1),
	Amount decimal(18, 2) NULL,
	BankID int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_BankAccountTransactions SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_BankAccountTransactions ON
GO
IF EXISTS(SELECT * FROM dbo.BankAccountTransactions)
	 EXEC('INSERT INTO dbo.Tmp_BankAccountTransactions (ID, Amount, BankID)
		SELECT ID, Amount, BankID FROM dbo.BankAccountTransactions WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_BankAccountTransactions OFF
GO
DROP TABLE dbo.BankAccountTransactions
GO
EXECUTE sp_rename N'dbo.Tmp_BankAccountTransactions', N'BankAccountTransactions', 'OBJECT' 
GO
ALTER TABLE dbo.BankAccountTransactions ADD CONSTRAINT
	PK_BankAccountTransactions PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.BankAccountTransactions ADD CONSTRAINT
	FK_BankID FOREIGN KEY
	(
	BankID
	) REFERENCES dbo.BankAccounts
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
----------------------------------------

USE [MarsaKAnzAbhar]
GO
Delete  from [Tickets];
DROP table [Tickets];
/****** Object:  Table [dbo].[Tickets]    Script Date: 7/18/2020 4:32:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tickets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [date] NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[SeaTransportTypeID] [int] NULL,
	[SeaTransportID] [int] NULL,
	[DriverID] [int] NULL,
	[CustomerID] [int] NULL,
	[DurationID] [int] NULL,
	[DurationValue] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[DiscountPercent] [decimal](18, 2) NULL,
	[PriceAfterDiscount] [nchar](10) NULL,
	[VAT] [decimal](18, 2) NULL,
	[PriceAfterVAT] [decimal](18, 2) NULL,
	[UserID] [int] NULL,
	[PayCash] [decimal](18, 2) NULL,
	[PayCard] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


-------------------------------------

ALTER TABLE Drivers
ALTER COLUMN Percentage decimal(18,2);

Alter table Price
Add DurationValue int null;

Alter table PriceChanging
Add DurationValue int null;

EXEC sp_rename 'PriceChanging.AccountantCommission', 'CashierExternCommission', 'COLUMN';

EXEC sp_rename 'Price.AccountantCommission', 'CashierExternCommission', 'COLUMN';

------------------28/07/2020-----------------------------------------
--- add column to get history of transactions ----------------------
alter table TreasuryTransactions
Add TicketID int;
Alter table TreasuryTransactions ADD CONSTRAINT FK_TicketID FOREIGN KEY (TicketID) REFERENCES Tickets(ID); 

alter table TreasuryTransactions
Add IncomeID int;
--Alter table TreasuryTransactions ADD CONSTRAINT FK_IncomeID FOREIGN KEY (IncomeID) REFERENCES Income(ID);

alter table TreasuryTransactions
Add ExpensesID int;
--Alter table TreasuryTransactions ADD CONSTRAINT FK_ExpensesID FOREIGN KEY (ExpensesID) REFERENCES Expenses(ID);

alter table TreasuryTransactions
Add BankAccountsID int;
Alter table TreasuryTransactions ADD CONSTRAINT FK_BankAccountsID FOREIGN KEY (BankAccountsID) REFERENCES BankAccounts(ID);


alter table TreasuryTransactions
Add Libelle nvarchar(255);

alter table TreasuryTransactions
Add IncomeFromCashierID int;
Alter table TreasuryTransactions ADD CONSTRAINT FK_IncomeFromCashierID FOREIGN KEY (IncomeFromCashierID) REFERENCES IncomeFromCashier(ID);

alter table Treasury
Add StartingBalance decimal(18,2);

alter table TreasuryTransactions
Add Date DateTime;


alter table SeaTransport
Add NumberReference int;

------------------------------------------Landing & payment
Alter table Landing
Drop column SeaTransportNo;
Alter table Landing
Add [SeaTransportID] [int] Not NULL;
Alter table Landing ADD CONSTRAINT FK_SeaTransportID FOREIGN KEY (SeaTransportID) REFERENCES SeaTransport(ID);

Alter table Landing
Add DailyAmount decimal(18,2) ;

Alter table Landing
Add PaymentDoneToDate Date ;

------------------------------------------------------------------------

CREATE TABLE [dbo].[LandingPaymentTransaction](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PayCash] decimal(18, 2) NULL,
	[PayCard] decimal(18, 2) NULL,
	[Date] DateTime NULL,
	[LandingID] [int] NULL,
CONSTRAINT [PK_LandingPaymentTransaction] PRIMARY KEY CLUSTERED 
(	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[LandingPaymentTransaction]  WITH CHECK ADD  CONSTRAINT [FK_LandingID] FOREIGN KEY([LandingID])
REFERENCES [dbo].[Landing] ([ID])
GO

alter table TreasuryTransactions
Add LandingPaymentID int;
Alter table TreasuryTransactions ADD CONSTRAINT FK_LandingPaymentID FOREIGN KEY (LandingPaymentID) REFERENCES LandingPaymentTransaction(ID);

alter table BankAccountTransactions
Add LandingPaymentID int;
Alter table BankAccountTransactions ADD CONSTRAINT FK_LandingPaymentIDBank 
FOREIGN KEY (LandingPaymentID) 
REFERENCES LandingPaymentTransaction(ID);

Alter table LandingPaymentTransaction
Add PaymentDoneToDate Date ;
----------------------------------------------------------------------------------------------------------------------------

alter table BankAccountTransactions
Add TicketID int;

Alter table BankAccountTransactions ADD CONSTRAINT FK_BankTicketID FOREIGN KEY (TicketID) REFERENCES Tickets(ID); 

alter table BankAccountTransactions
Add Libelle nvarchar(255);
----------------------------------------------------------------------------------------------------------

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TicketsDeleted](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TicketID] [int] NOT NULL,
	[StartDate] [date] NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[SeaTransportTypeID] [int] NULL,
	[SeaTransportID] [int] NULL,
	[DriverID] [int] NULL,
	[CustomerID] [int] NULL,
	[DurationID] [int] NULL,
	[DurationValue] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[DiscountPercent] [decimal](18, 2) NULL,
	[PriceAfterDiscount] [nchar](10) NULL,
	[VAT] [decimal](18, 2) NULL,
	[PriceAfterVAT] [decimal](18, 2) NULL,
	[UserID] [int] NULL,
	[PayCash] [decimal](18, 2) NULL,
	[PayCard] [decimal](18, 2) NULL,
 CONSTRAINT [PK_TicketsDeleted] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

Alter table BankAccountTransactions DROP CONSTRAINT FK_BankTicketID;

Alter table TreasuryTransactions DROP CONSTRAINT FK_TicketID;


-----------to save the date of start date for payment transaction
Alter table LandingPaymentTransaction
Add PaymentTransactionStartDate Date ;


