using Application.Factories;
using Domain.Aggregates;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.GetExpenses;

public class GetExpensesCommandHandler : IRequestHandler<GetExpensesCommand, GetExpensesCommandResult>
{
    private readonly ILogger<GetExpensesCommandHandler> _logger;
    private readonly GetExpensesResultFactory _factory;

    public GetExpensesCommandHandler(ILogger<GetExpensesCommandHandler> logger, GetExpensesResultFactory factory)
    {
        _logger = logger;
        _factory = factory;
    }

    public async Task<GetExpensesCommandResult> Handle(GetExpensesCommand request, CancellationToken cancellationToken)
    {
        //create aggregate, save in database
        await Task.Delay(1, cancellationToken);
        var expenses = new List<ExpenseAggregate>() { new("school",1600), new("house",4000) };

        _logger.LogInformation("Aggregate Expense retried from database");

        //return result
        return _factory.Create(expenses);
    }
}