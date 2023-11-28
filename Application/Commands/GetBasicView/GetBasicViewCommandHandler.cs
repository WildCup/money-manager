using Application.Factories;
using Domain.Aggregates;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.GetBasicView;

public class GetBasicViewCommandHandler : IRequestHandler<GetBasicViewCommand, GetBasicViewCommandResult>
{
    private readonly ILogger<GetBasicViewCommandHandler> _logger;
    private readonly GetBasicViewResultFactory _factory;

    public GetBasicViewCommandHandler(ILogger<GetBasicViewCommandHandler> logger, GetBasicViewResultFactory factory)
    {
        _logger = logger;
        _factory = factory;
    }

    public async Task<GetBasicViewCommandResult> Handle(GetBasicViewCommand request, CancellationToken cancellationToken)
    {
        //create aggregate, save in database
        await Task.Delay(1, cancellationToken);
        var expenses = new List<ExpenseAggregate>() { new("school",1600), new("house",4000) };

        _logger.LogInformation("Aggregate Expense retried from database");

        //return result
        return _factory.Create(expenses);
    }
}