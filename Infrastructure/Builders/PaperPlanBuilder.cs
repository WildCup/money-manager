namespace Infrastructure.Builders;

public class PaperPlanBuilder : IPlanBuilder
{
	private List<string> _plan = new();
	
	public void Reset()
	{
		_plan = new();
	}
	
 	public void BuildBase()
	{
		_plan.Add("-Own Company");
		_plan.Add("	-save money");	
		_plan.Add("		-10");
		_plan.Add("		-200");
		_plan.Add("		-300");
		_plan.Add("	-open company");	
		_plan.Add("		-register");
		_plan.Add("		-start");
	}

	public void BuildFuture()
	{
		_plan.Add("-Stocks");
		_plan.Add("	-investigate");	
		_plan.Add("		-online");
		_plan.Add("		-ask friends");
		_plan.Add("	-invest");	
		_plan.Add("		-100");
		_plan.Add("		-200");
		_plan.Add("		-300");
	}

	public void BuildPresent()
	{
		_plan.Add("-Business");
		_plan.Add("	-product");	
		_plan.Add("		-investigate");
		_plan.Add("		-make");
		_plan.Add("		-test");
		_plan.Add("	-sell");	
		_plan.Add("		-100");
		_plan.Add("		-200");
		_plan.Add("		-300");
	}


	public IReadOnlyCollection<string> GetPlan()
	{
		var tmp = _plan;
		Reset();

		return tmp;
	}
}