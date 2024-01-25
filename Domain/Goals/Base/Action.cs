using MoneyManager.Infrastructure.Exceptions;

namespace Domain.Goals.Base;

public class Action
{
	public Guid Id { get; private set; } = new();
	public string Name { get; private set; }
	public Step? Step { get; set; }

    public Action(string name)
    {
        Name = name;
    }
}