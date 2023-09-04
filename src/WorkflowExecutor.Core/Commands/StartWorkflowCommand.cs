using Ardalis.Result;
using WorkflowCore.Interface;
using WorkflowCore.Services.DefinitionStorage;
using WorkflowExecutor.Core.Common;
using WorkflowExecutor.Infrastructure.Records;
using WorkflowExecutor.Infrastructure.Requests;
using WorkflowExecutor.Infrastructure.Responses;

namespace WorkflowExecutor.Core.Commands;

public record StartWorkflowCommand(StartWorkflowRequest Request) : IRequestWrapper<StartWorkflowResponse>;

public class StartWorkflowCommandHandler : IHandlerWrapper<StartWorkflowCommand, StartWorkflowResponse>
{
    private readonly IWorkflowHost _workflowHost;
    private readonly IDefinitionLoader _workflowDefinitionLoader;

    public StartWorkflowCommandHandler(IWorkflowHost workflowHost, IDefinitionLoader workflowDefinitionLoader)
    {
        _workflowHost = workflowHost;
        _workflowDefinitionLoader = workflowDefinitionLoader;
    }

    public Task<Result<StartWorkflowResponse>> Handle(StartWorkflowCommand command, CancellationToken cancellationToken)
    {
        var def = _workflowDefinitionLoader.LoadDefinition(GetTestDefinitionJson(command.Request.Name), Deserializers.Json);
        _workflowHost.Start();
        var workflowId = _workflowHost.StartWorkflow(def.Id).Result;

        var response = new StartWorkflowResponse(new WorkflowRecord(1, workflowId));
        return Task.FromResult(Result.Success(response));
    }

    private string GetTestDefinitionJson(string projectName)
    {
        return File.ReadAllText(@$"D:\test-workflows\{projectName}-workflow.json");
    }
}

