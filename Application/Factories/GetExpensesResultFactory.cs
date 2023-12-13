using MoneyManager.Application.Commands.GetExpenses;
using MoneyManager.Domain.Aggregates;

namespace MoneyManager.Application.Factories;


public abstract class GetExpensesResultFactory
{
	public abstract GetExpensesCommandResult Create(List<ExpenseAggregate> expenses);
}

public class GetExpensesForUserResultFactory : GetExpensesResultFactory
{
	public override GetExpensesCommandResult Create(List<ExpenseAggregate> expenses)
	{
		var all = new List<GetExpenseDto>();
		foreach (var expense in expenses)
			all.Add(new(expense.State.Id, expense.State.Amount));
		
		return new GetExpensesForUserCommandResult(){ AllExpenses = all };
	}
}

public class GetExpensesForPremiumUserResultFactory : GetExpensesResultFactory
{
	public override GetExpensesCommandResult Create(List<ExpenseAggregate> expenses)
	{
		var all = new List<GetExpenseDetailedDto>();
		foreach (var expense in expenses)
			all.Add(new(expense.State.Id, expense.State.Name, expense.State.Amount));
		
		return new GetExpensesForPremiumUserCommandResult(){ AllExpenses = all };
	}
}

public class GetExpensesForAdminResultFactory : GetExpensesResultFactory
{
	public override GetExpensesCommandResult Create(List<ExpenseAggregate> expenses)
	{
		var all = new List<GetExpenseDebugDto>();
		foreach (var expense in expenses)
			all.Add(new(expense.State.Id, expense.State.Name, expense.State.Amount, expense.State.Version));
		
		return new GetExpensesForAdminCommandResult(){ AllExpenses = all };
	}
}