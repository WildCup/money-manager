using MoneyManager.Domain.Aggregates.Abstraction;

namespace MoneyManager.Infrastructure.Abstraction;

public interface IAggregateRepository<T, TState>  where T : Aggregate<TState>, new() where TState : AggregateState, new()
{
	IEnumerable<TState> GetAll();
	T Get(Guid id);
	void Save(T entity);
}