using MediatR;

namespace Application.Commands.CreateExpense;

public class CreateExpenseCommand : IRequest<CreateExpenseCommandResult>
{
	public string Name { get; set; }
	public float Amount { get; set; }
}