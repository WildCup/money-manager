using MediatR;
using Microsoft.Extensions.Logging;
using MoneyManager.Domain.Aggregates;
using MoneyManager.Infrastructure.Abstraction;

namespace MoneyManager.Application.Commands.CreateExpense;

public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, CreateExpenseCommandResult>
{
    private readonly ILogger<CreateExpenseCommandHandler> _logger;
    private readonly IExpenseRepository _repo;

    public CreateExpenseCommandHandler(ILogger<CreateExpenseCommandHandler> logger, IExpenseRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    public async Task<CreateExpenseCommandResult> Handle(CreateExpenseCommand command, CancellationToken cancellationToken)
    {
        var expense = new ExpenseAggregate(command.Name, command.Amount, command.Category);

        await Task.Delay(1000, cancellationToken);
        _logger.LogInformation("Aggregate Expense created");

        _repo.Save(expense);
        return new CreateExpenseCommandResult();
    }
}