using Microsoft.Extensions.Caching.Memory;
using MoneyManager.Application.Commands.CreateExpense;
using MoneyManager.Application.Factories;
using MoneyManager.Infrastructure.Abstraction;
using MoneyManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IExpenseRepository, ExpenseRepository>();
builder.Services.AddSingleton<IMemoryCache>(provider => new MemoryCache(new MemoryCacheOptions{  }));

builder.Services.AddTransient<GetExpensesResultFactory>(provider => 
{
	var config = provider.GetRequiredService<IConfiguration>();
	var role = config["Role"];

	//todo: read role from bearer token
	return role switch
	{
		"User" => new GetExpensesForUserResultFactory(),
		"PremiumUser" => new GetExpensesForPremiumUserResultFactory(),
		"Admin" => new GetExpensesForAdminResultFactory(),
		_ => throw new ArgumentException($"{role} is incorrect"),
	};
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateExpenseCommand).Assembly));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
