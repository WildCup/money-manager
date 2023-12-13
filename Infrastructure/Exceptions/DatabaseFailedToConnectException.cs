namespace MoneyManager.Infrastructure.Exceptions;

public class DatabaseFailedToConnectException : Exception
{
	public DatabaseFailedToConnectException() : base("Could not retrieve data from database")
	{
		
	}
}