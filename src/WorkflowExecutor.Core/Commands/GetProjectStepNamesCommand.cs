using Ardalis.Result;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Models;
using WorkflowExecutor.Core.Common;
using WorkflowExecutor.Infrastructure.Records;
using WorkflowExecutor.Infrastructure.Requests;
using WorkflowExecutor.Infrastructure.Responses;

namespace WorkflowExecutor.Core.Commands;

public record GetProjectStepNamesCommand(ProjectStepNamesRequest Request) : IRequestWrapper<ProjectStepNamesResponse>;

public class GetProjectStepNamesCommandHandler : IHandlerWrapper<GetProjectStepNamesCommand, ProjectStepNamesResponse>
{
    private readonly IServiceProvider _serviceProvider;

    public GetProjectStepNamesCommandHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<Result<ProjectStepNamesResponse>> Handle(GetProjectStepNamesCommand command, CancellationToken cancellationToken)
    {
        var registeredSteps = _serviceProvider.GetServices<StepBody>();
        var stepNames = registeredSteps.Select(s =>
        {
            var name = s.ToString()!;
            return name[(name.LastIndexOf('.') + 1)..];
        });
        var response = new ProjectStepNamesResponse(new ProjectStepNamesRecord(command.Request.ProjectName, stepNames.ToArray()));
        return Task.FromResult(Result.Success(response));
    }
}

