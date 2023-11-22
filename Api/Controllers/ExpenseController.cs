using Application.Commands.CreateExpense;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpenseController : ControllerBase
{
    private readonly ILogger<ExpenseController> _logger;
    private readonly IMediator _mediator;

    public ExpenseController(ILogger<ExpenseController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost(Name = "GetWeatherForecast")]
    public async Task CreateAsync()
    {
        await _mediator.Send(new CreateExpenseCommand());
    }
}
