using WorkflowExecutor.Infrastructure.Records;

namespace WorkflowExecutor.Infrastructure.Responses;

public record StartWorkflowResponse(WorkflowRecord Workflow);