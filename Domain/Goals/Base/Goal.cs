using MoneyManager.Infrastructure.Exceptions;

namespace Domain.Goals.Base;

public class Goal
{
	public Guid Id { get; private set; } = new();
	public string Name { get; private set; }
    public Plan? Plan { get; set; }
	private readonly List<Step> _steps = new();
	public IReadOnlyCollection<Step> Steps { get; private set; } = new List<Step>();
	private bool _built;
	
	public Goal(string name)
    {
        Name = name;
    }

	public Step Add(Step step)
	{
		if(_built) throw new IncorrectBuildException(Name);

		_steps.Add(step);
		step.Goal = this;
		return step;
	}

	public Plan Build()
	{
		if(_built) throw new IncorrectBuildException(Name);
		_built = true;

		Steps = _steps;
		foreach (var step in _steps)		
			if(step.Goal != this) throw new IncorrectBuildException(Name);

		if(Plan == null) throw new IncorrectBuildException(Name);

		return Plan;
	}
}
