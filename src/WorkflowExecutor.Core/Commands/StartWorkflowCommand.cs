using WorkflowExecutor.Infrastructure.Common.Interfaces;
using WorkflowExecutor.Infrastructure.Common.Wrappers;
using WorkflowExecutor.Infrastructure.Models;
using WorkflowExecutor.Infrastructure.Records;
using WorkflowExecutor.Infrastructure.Requests;
using WorkflowExecutor.Infrastructure.Responses;

namespace WorkflowExecutor.Core.Commands;

public record StartWorkflowCommand(StartWorkflowRequest Request) : IRequestWrapper<StartWorkflowResponse>;

public class StartWorkflowCommandHandler : IHandlerWrapper<StartWorkflowCommand, StartWorkflowResponse>
{
    public Task<IResponse<StartWorkflowResponse>> Handle(StartWorkflowCommand request, CancellationToken cancellationToken)
    {
        var response = new StartWorkflowResponse(new WorkflowRecord(1, "HelloWorld"));
        return Task.FromResult(Response.Success(response));
    }
}

