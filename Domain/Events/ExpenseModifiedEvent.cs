using Domain.Enums;

namespace MoneyManager.Domain.Events;

public class ExpenseModifiedEvent : AggregateEvent
{
	public required string Name { get; set; }
	public required float Amount { get; set; }
	public required CategoryType Category { get; set; }
}
