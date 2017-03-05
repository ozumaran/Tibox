CREATE PROCEDURE dbo.CustomerSearchByNames 
	@firstName NVARCHAR(40)
	,@lastName NVARCHAR(40)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id]
		,[FirstName]
		,[LastName]
		,[City]		
		,[Country]
		,[Phone]
	FROM dbo.Customer
	WHERE FirstName = @firstName
		AND LastName = @lastName

	SET NOCOUNT OFF;
END
GO


