namespace Domain.Abstraction;

public abstract class AggregateEvent
{
	public AggregateEvent()
	{

	}

	public Guid Id { get; set; } = Guid.NewGuid();
	public DateTime On { get; set; } = DateTime.Now;
}
