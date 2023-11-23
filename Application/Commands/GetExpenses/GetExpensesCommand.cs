using MediatR;

namespace Application.Commands.GetExpenses;

public class GetExpensesCommand : IRequest<GetExpensesCommandResult>
{
	public string Name { get; set; }
	public float Amount { get; set; }
}