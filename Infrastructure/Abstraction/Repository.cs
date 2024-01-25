using Microsoft.Extensions.Caching.Memory;
using MoneyManager.Domain.Abstraction;
using MoneyManager.Domain.Aggregates.Abstraction;

namespace MoneyManager.Infrastructure.Abstraction;

public class AggregateRepository<T, TState> : IAggregateRepository<T, TState>  where T : Aggregate<TState>, new() where TState : AggregateState, new()
{
	protected readonly IMemoryCache _memoryCache;
	//aggregateId -> list of all events
	//states-type -> list of all states

    public AggregateRepository(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public IEnumerable<TState> GetAll()
	{
		var obj = _memoryCache.Get($"states-{typeof(TState)}") ?? new List<TState>();
		var states = (List<TState>)obj;

		return states.AsEnumerable();
	}

	public T Get(Guid aggregateId)
	{
		var obj = _memoryCache.Get(aggregateId) ?? new List<AggregateEvent>();
		var events = (List<AggregateEvent>)obj;

		var aggregate = new T();
		aggregate.Build(events);

		return aggregate;
	}

	public void Save(T aggregate)
	{
		//save all events
		var obj = _memoryCache.Get(aggregate.State.Id) ?? new List<AggregateEvent>();
		var events = (List<AggregateEvent>)obj;

		foreach (var @event in aggregate.UncommittedEvents)
			events.Add(@event);

		_memoryCache.Set(aggregate.State.Id, events);
		var test = _memoryCache.Get(aggregate.State.Id);
		
		//save newest state
		obj = _memoryCache.Get($"states-{typeof(TState)}") ?? new List<TState>();
		var states = (List<TState>)obj;

		aggregate.Build(aggregate.UncommittedEvents.ToList());
		states.Add(aggregate.State);

		_memoryCache.Set($"state-{typeof(TState)}", states);
		var test2 = _memoryCache.Get($"state-{typeof(TState)}");
	}
}