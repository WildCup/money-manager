namespace Application.Models;

public class Plan
{
    public List<Node> Nodes { get; set; } = new();
}

public class Node
{
    public Node(string name)
    {
        Category = name;
    }

    public string Category { get; init; } 
    public List<ExpenseDto> Expenses { get; set; } = new();
}

public class ExpenseDto
{
    public ExpenseDto(float amount)
    {
        Amount = amount;
    }
    
    public float Amount { get; set; }
}