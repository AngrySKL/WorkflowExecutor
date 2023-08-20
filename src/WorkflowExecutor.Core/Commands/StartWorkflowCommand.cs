using Ardalis.Result;
using WorkflowExecutor.Core.Common;
using WorkflowExecutor.Infrastructure.Records;
using WorkflowExecutor.Infrastructure.Requests;
using WorkflowExecutor.Infrastructure.Responses;

namespace WorkflowExecutor.Core.Commands;

public record StartWorkflowCommand(StartWorkflowRequest Request) : IRequestWrapper<StartWorkflowResponse>;

public class StartWorkflowCommandHandler : IHandlerWrapper<StartWorkflowCommand, StartWorkflowResponse>
{
    public Task<Result<StartWorkflowResponse>> Handle(StartWorkflowCommand command, CancellationToken cancellationToken)
    {
        var response = new StartWorkflowResponse(new WorkflowRecord(1, command.Request.Name));
        return Task.FromResult(Result.Success(response));
    }
}

