using MoneyManager.Infrastructure.Exceptions;

namespace Domain.Goals.Base;

public class Step
{
	public Guid Id { get; private set; } = new();
	public string Name { get; private set; }
	public Goal? Goal { get; set; }
	private readonly List<Action> _actions = new();
	public IReadOnlyCollection<Action> Actions { get; private set; } = new List<Action>();
	private bool _built;
	
	public Step(string name)
    {
        Name = name;
    }

	public Step Add(Action action)
	{
		if(_built) throw new IncorrectBuildException(Name);

		_actions.Add(action);
		action.Step = this;
		return this;
	}

	public Goal Build()
	{
		if(_built) throw new IncorrectBuildException(Name);
		_built = true;

		Actions = _actions;
		foreach (var step in _actions)		
			if(step.Step != this) throw new IncorrectBuildException(Name);

		if(Goal == null) throw new IncorrectBuildException(Name);

		return Goal;
	}
}
