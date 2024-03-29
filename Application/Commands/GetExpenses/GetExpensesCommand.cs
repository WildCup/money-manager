using MediatR;

namespace MoneyManager.Application.Commands.GetExpenses;

public class GetExpensesCommand : IRequest<GetExpensesCommandResult>
{
	public required string Name { get; set; }
}