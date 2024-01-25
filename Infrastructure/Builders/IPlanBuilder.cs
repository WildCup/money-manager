namespace Infrastructure.Builders;

public interface IPlanBuilder
{
	void BuildBase();
	void BuildPresent();
	void BuildFuture();
}