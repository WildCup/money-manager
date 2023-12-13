using Microsoft.Extensions.Caching.Memory;
using MoneyManager.Domain.Aggregates;
using MoneyManager.Infrastructure.Abstraction;

namespace MoneyManager.Infrastructure.Repositories;

public class ExpenseRepository : AggregateRepository<ExpenseAggregate, ExpenseAggregateState>, IExpenseRepository
{
    public ExpenseRepository(IMemoryCache memoryCache): base(memoryCache) { }
}