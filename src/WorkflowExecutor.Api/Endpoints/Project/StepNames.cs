using FastEndpoints;
using MediatR;
using WorkflowExecutor.Core.Commands;
using WorkflowExecutor.Infrastructure.Requests;
using WorkflowExecutor.Infrastructure.Responses;

namespace WorkflowExecutor.Api.Endpoints.Project;

public class StepNames : Endpoint<ProjectStepNamesRequest, ProjectStepNamesResponse>
{
    private readonly IMediator _mediator;

    public StepNames(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get(ProjectStepNamesRequest.Route);
        Roles("Admin");
        Options(x => x.WithTags("ProjectEndpoints"));
    }

    public override async Task HandleAsync(ProjectStepNamesRequest request, CancellationToken cancellationToken = default)
    {
        var command = new GetProjectStepNamesCommand(request);
        var result = await _mediator.Send(command, cancellationToken);
        await SendAsync(result.Value, cancellation: cancellationToken);
    }
}
