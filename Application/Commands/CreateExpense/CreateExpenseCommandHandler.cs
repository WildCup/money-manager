using MediatR;
using Microsoft.Extensions.Logging;

namespace MoneyManager.Application.Commands.CreateExpense;

public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, CreateExpenseCommandResult>
{
    private readonly ILogger<CreateExpenseCommandHandler> _logger;

    public CreateExpenseCommandHandler(ILogger<CreateExpenseCommandHandler> logger)
    {
        _logger = logger;
    }

    public async Task<CreateExpenseCommandResult> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        //create aggregate, save in database
        await Task.Delay(1, cancellationToken);

        _logger.LogInformation("Aggregate Expense created");

        //return result
        return new CreateExpenseCommandResult();
    }
}