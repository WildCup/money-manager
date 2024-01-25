using MoneyManager.Infrastructure.Exceptions;

namespace Domain.Goals.Base;

public class Plan
{
	public Guid Id { get; private set; } = new();
	public string Name { get; private set; }
	private readonly List<Goal> _goals = new();
	public IReadOnlyCollection<Goal> Goals { get; private set; } = new List<Goal>();
	private bool _built;
	
	public Plan(string name)
    {
        Name = name;
    }

	public Goal Add(Goal goal)
	{
		if(_built) throw new IncorrectBuildException(Name);

		_goals.Add(goal);
		goal.Plan = this;
		return goal;
	}

	public Plan Build()
	{
		if(_built) throw new IncorrectBuildException(Name);
		_built = true;

		Goals = _goals;
		foreach (var step in _goals)		
			if(step.Plan != this) throw new IncorrectBuildException(Name);

		return this;
	}
}
