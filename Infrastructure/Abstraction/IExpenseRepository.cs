using MoneyManager.Domain.Aggregates;

namespace MoneyManager.Infrastructure.Abstraction;

public interface IExpenseRepository : IAggregateRepository<ExpenseAggregate, ExpenseAggregateState>
{

}