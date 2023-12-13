namespace MoneyManager.Domain.Abstraction;

public abstract class AggregateEvent
{
	public AggregateEvent()
	{

	}

	public Guid Id { get; set; } = Guid.NewGuid();
	public Guid AggregateId { get; set; } = Guid.NewGuid();
	public int Version { get; set; } = -1;
	public DateTime On { get; set; } = DateTime.Now;
}
