using MoneyManager.Application.Factories;
using MoneyManager.Domain.Aggregates;
using MediatR;
using Microsoft.Extensions.Logging;
using MoneyManager.Infrastructure.Abstraction;
using Domain.Enums;

namespace MoneyManager.Application.Commands.GetExpenses;

public class GetExpensesCommandHandler : IRequestHandler<GetExpensesCommand, GetExpensesCommandResult>
{
    private readonly ILogger<GetExpensesCommandHandler> _logger;
    private readonly IExpenseRepository _repo;
    private readonly GetExpensesResultFactory _factory;

    public GetExpensesCommandHandler(ILogger<GetExpensesCommandHandler> logger, GetExpensesResultFactory factory, IExpenseRepository repo)
    {
        _logger = logger;
        _factory = factory;
        _repo = repo;
    }

    public async Task<GetExpensesCommandResult> Handle(GetExpensesCommand request, CancellationToken cancellationToken)
    {
        //create aggregate, save in database
        await Task.Delay(1, cancellationToken);
        var expenses = new List<ExpenseAggregate>() { new("school",1600, CategoryType.Necessary), new("house",4000, CategoryType.Necessary) };

        var result = _repo.GetAll();
        _logger.LogInformation("Aggregate Expense retried from database");

        //return result
        return _factory.Create(expenses);
    }
}