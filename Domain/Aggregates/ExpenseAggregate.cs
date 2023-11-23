using Domain.Events;

namespace Domain.Aggregates;

public partial class ExpenseAggregate : Aggregate<ExpenseAggregateState>
{
	public ExpenseAggregate(string name, float amount)
	{
		AddEvent(new ExpenseCreatedEvent(name, amount));
	}

	public void Modify(string name, float amount)
	{
		AddEvent(new ExpenseModifiedEvent(name, amount));
	}

	public void Delete()
	{
		AddEvent(new ExpenseDeletedEvent());
	}

	public void Handle(ExpenseCreatedEvent @event)
	{
		State = new ExpenseAggregateState()
		{
			Name = @event.Name,
			Amount = @event.Amount 
		};;
	}

	public void Handle(ExpenseModifiedEvent @event)
	{
		State = State with 
		{
			Name = @event.Name,
			Amount = @event.Amount 
		};
	}

	public void Handle(ExpenseDeletedEvent @event)
	{
		State = State with { IsDeleted = true };
	}
}

public record ExpenseAggregateState : AggregateState
{
	public string Name { get; init; } = "";
	public float Amount { get; init; }
}
