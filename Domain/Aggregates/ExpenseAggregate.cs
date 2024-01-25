using Domain.Enums;
using MoneyManager.Domain.Aggregates.Abstraction;
using MoneyManager.Domain.Events;

namespace MoneyManager.Domain.Aggregates;

public class ExpenseAggregate : Aggregate<ExpenseAggregateState>
{
	public ExpenseAggregate() { }

	public ExpenseAggregate(string name, float amount, CategoryType category)
	{
		AddEvent(new ExpenseCreatedEvent()
		{
			Name = name,
			Amount = amount,
			Category = category,
		});

		if(category == CategoryType.Fun && amount > 1000)
			Console.WriteLine("WARNING: spending large amount of money for fun!!");
	}

	public void Modify(string name, float amount, CategoryType category)
	{
		if(State.Name == name && State.Amount == amount && State.Category == category) return;
		AddEvent(new ExpenseModifiedEvent()
		{
			Name = name,
			Amount = amount,
			Category = category,
		});
	}

	public void Delete()
	{
		if(State.IsDeleted) return;
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
	public CategoryType Category { get; init; }
}
