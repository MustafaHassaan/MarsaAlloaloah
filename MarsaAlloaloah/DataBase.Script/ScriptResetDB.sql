DELETE from BankAccountTransactions;
DBCC CHECKIDENT('MarsaKanzAbhar.dbo.BankAccountTransactions', RESEED, 0);
Delete from Tickets;
DBCC CHECKIDENT('MarsaKanzAbhar.dbo.Tickets', RESEED, 0);

--
delete from TreasuryTransactions;
DBCC CHECKIDENT('MarsaKanzAbhar.dbo.TreasuryTransactions', RESEED, 0);
--
delete from lnkTicketAddon;
DBCC CHECKIDENT('MarsaKanzAbhar.dbo.lnkTicketAddon', RESEED, 0);
delete from Income;
DBCC CHECKIDENT('MarsaKanzAbhar.dbo.Income', RESEED, 0);
delete from Expenses;
DBCC CHECKIDENT('MarsaKanzAbhar.dbo.Expenses', RESEED, 0);