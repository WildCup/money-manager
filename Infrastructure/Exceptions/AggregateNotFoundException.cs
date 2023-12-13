namespace MoneyManager.Infrastructure.Exceptions;

public class AggregateNotFoundException : Exception
{
	public AggregateNotFoundException(Guid id) : base($"Aggregate with id: {id} was not found")
	{
		
	}
}