namespace MoneyManager.Domain.Events;

public class ExpenseCreatedEvent : AggregateEvent
{
	public ExpenseCreatedEvent(string name, float amount): base()
	{
		Name = name;
		Amount = amount;
	}

	public string Name { get; set; }
	public float Amount { get; set; }
}
