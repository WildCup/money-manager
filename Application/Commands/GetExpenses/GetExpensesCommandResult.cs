namespace Application.Commands.GetExpenses;

public abstract class GetExpensesCommandResult
{

}

public class GetExpensesForUserCommandResult : GetExpensesCommandResult
{
	public List<GetExpenseDto> AllExpenses { get; set; } = new();
}

public class GetExpensesForPremiumUserCommandResult : GetExpensesCommandResult
{
	public List<GetExpenseDetailedDto> AllExpenses { get; set; } = new();
}

public class GetExpensesForAdminCommandResult : GetExpensesCommandResult
{
	public List<GetExpenseDebugDto> AllExpenses { get; set; } = new();
}

public record GetExpenseDto(Guid Id, float Amount);
public record GetExpenseDetailedDto(Guid Id, string Name, float Amount);
public record GetExpenseDebugDto(Guid Id, string Name, float Amount, int Version);