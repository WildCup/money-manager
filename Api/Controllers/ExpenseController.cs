using Application.Commands.CreateExpense;
using Application.Commands.GetExpenses;
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

    [HttpGet(Name = "GetExpenses")]
    public async Task<GetExpensesCommandResult> GetAllAsync()
    {
        return await _mediator.Send(new GetExpensesCommand());
    }

    [HttpPost(Name = "AddExpense")]
    public async Task CreateAsync()
    {
        await _mediator.Send(new CreateExpenseCommand());
    }
}
