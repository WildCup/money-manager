using MediatR;

namespace Application.Commands.GetBasicView;

public class GetBasicViewCommand : IRequest<GetBasicViewCommandResult>
{
	public string Name { get; set; }
	public float Amount { get; set; }
}