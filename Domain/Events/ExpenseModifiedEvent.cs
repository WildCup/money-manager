namespace Domain.Events;

public class ExpenseModifiedEvent : AggregateEvent
{
	public ExpenseModifiedEvent(string name, float amount): base()
	{
		Name = name;
		Amount = amount;
	}

	public string Name { get; set; }
	public float Amount { get; set; }
}
