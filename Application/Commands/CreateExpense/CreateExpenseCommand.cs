using MediatR;

namespace MoneyManager.Application.Commands.CreateExpense;

public class CreateExpenseCommand : IRequest<CreateExpenseCommandResult>
{
	public required string Name { get; set; }
	public required float Amount { get; set; }
}