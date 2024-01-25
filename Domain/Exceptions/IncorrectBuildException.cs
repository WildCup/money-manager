namespace MoneyManager.Infrastructure.Exceptions;

public class IncorrectBuildException : Exception
{
	public IncorrectBuildException(string name) : base($"Builder could not build {name}")
	{
		
	}
}