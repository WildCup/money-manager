namespace Application.Commands.GetBasicView;

public abstract class GetBasicViewCommandResult
{

}

public class GetBasicViewForUserCommandResult : GetBasicViewCommandResult
{
	public List<GetExpenseDto> AllExpenses { get; set; } = new();
}

public class GetBasicViewForPremiumUserCommandResult : GetBasicViewCommandResult
{
	public List<GetExpenseDetailedDto> AllExpenses { get; set; } = new();
}

public class GetBasicViewForAdminCommandResult : GetBasicViewCommandResult
{
	public List<GetExpenseDebugDto> AllExpenses { get; set; } = new();
}

public record GetExpenseDto(Guid Id, float Amount);
public record GetExpenseDetailedDto(Guid Id, string Name, float Amount);
public record GetExpenseDebugDto(Guid Id, string Name, float Amount, int Version);