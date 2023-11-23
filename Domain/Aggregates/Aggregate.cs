namespace Domain.Aggregates;

public class Aggregate<TState> where TState : AggregateState, new()
{
	public TState State { get; protected set; } = new();

	public List<AggregateEvent> UncommittedEvents { get; private set; } = new();

	private void HandleEvent(AggregateEvent @event)
	{
		var method = this.GetType().GetMethod("Handle", new Type[] { @event.GetType() }) ?? throw new ArgumentNullException($"You must handle event {@event.GetType().Name} in aggregate!!");

		method.Invoke(this, new object[] { @event });

		UncommittedEvents.Add(@event);
	}

	protected void AddEvent(AggregateEvent @event)
	{
		HandleEvent(@event);
	}

	public void Build(IEnumerable<AggregateEvent> events)
	{
		foreach (var @event in events)
			HandleEvent(@event);
		
		UncommittedEvents.Clear();
	}
}

public abstract record AggregateState
{
    public Guid Id { get; init; } = Guid.NewGuid();

	public int Version { get; init; } = -1;

	public bool IsDeleted { get; init; }
}
