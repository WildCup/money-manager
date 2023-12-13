using MoneyManager.Application.Commands.CreateExpense;
using MoneyManager.Application.Commands.GetExpenses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MoneyManager.Api.Controllers;

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

    [HttpGet("expenses")]
    public async Task<GetExpensesCommandResult> GetAllAsync()
    {
        return await _mediator.Send(new GetExpensesCommand());
    }

    [HttpPost("expenses")]
    public async Task CreateAsync(CreateExpenseCommand model)
    {
        await _mediator.Send(model);
    }
}
