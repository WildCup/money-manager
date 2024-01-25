using Domain.Goals.Base;
using Action = Domain.Goals.Base.Action;

namespace Infrastructure.Builders;

public class DefaultCompanyBuilder : IPlanBuilder
{
	private Plan _plan;

	public DefaultCompanyBuilder()
	{
		_plan = new Plan("Default Company Plan");
	}
	
	public void Reset()
	{
		_plan = new Plan("Default Company Plan");
	}
	
 	public void BuildBase()
	{
		_plan
		.Add(new Goal("Own Company"))
		.Add(new Step("save money"))	
		.Add(new Action("10"))
		.Add(new Action("200"))
		.Add(new Action("300"))
		.Build()
		.Add(new Step("open company"))	
		.Add(new Action("register"))
		.Add(new Action("start"))
		.Build()
		.Build();
	}

	public void BuildFuture()
	{
		_plan
		.Add(new Goal("Stocks"))
		.Add(new Step("investigate"))	
		.Add(new Action("online"))
		.Add(new Action("ask friends"))
		.Build()
		.Add(new Step("invest"))	
		.Add(new Action("100"))
		.Add(new Action("200"))
		.Add(new Action("300"))
		.Build()
		.Build();
	}
	
	public void BuildPresent()
	{
		_plan
		.Add(new Goal("Business"))
		.Add(new Step("product"))	
		.Add(new Action("investigate"))
		.Add(new Action("make"))
		.Add(new Action("test"))
		.Build()
		.Add(new Step("sell"))	
		.Add(new Action("100"))
		.Add(new Action("200"))
		.Add(new Action("300"))
		.Build()
		.Build();
	}


	public Plan GetPlan()
	{
		var tmp = _plan.Build();
		Reset();

		return tmp;
	}
}