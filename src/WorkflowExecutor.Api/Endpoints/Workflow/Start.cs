using FastEndpoints;
using MediatR;
using WorkflowExecutor.Core.Commands;
using WorkflowExecutor.Infrastructure.Requests;
using WorkflowExecutor.Infrastructure.Responses;

namespace WorkflowExecutor.Api.Endpoints.Workflow;

public class Start : Endpoint<StartWorkflowRequest, StartWorkflowResponse>
{
    private readonly IMediator _mediator;

    public Start(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post(StartWorkflowRequest.Route);
        AllowAnonymous();
        Options(x => x.WithTags("WorkflowEndpoints"));
    }

    public override async Task HandleAsync(StartWorkflowRequest request, CancellationToken cancellationToken = default)
    {
        var command = new StartWorkflowCommand(request);
        var result = await _mediator.Send(command, cancellationToken);
        await SendAsync(result.Value, cancellation: cancellationToken);
    }
}