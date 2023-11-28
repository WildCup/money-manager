using Application.Commands.GetExpenses;
using Application.Models;
using Microsoft.VisualBasic;

namespace Application.Factories;


public interface IPlanBuilder
{
	void AddCategory(string name);
	void AddExpense(float amount);
}

public class PlanBuilder : IPlanBuilder
{
	private Plan _plan = new();
	private Node? _current;

    public void AddCategory(string name)
    {
        _current = new Node(name);
    }

    public void AddExpense(float amount)
    {
		if(_current == null) throw new NullReferenceException("Node cannot be null");
        _current.Expenses.Add(new(amount));
    }

	public void BuildCategory()
    {
		if(_current == null) throw new NullReferenceException("Node cannot be null");
		_plan.Nodes.Add(_current);
    }
}