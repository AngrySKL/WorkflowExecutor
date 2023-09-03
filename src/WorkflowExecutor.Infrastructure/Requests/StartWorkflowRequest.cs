namespace WorkflowExecutor.Infrastructure.Requests;

public record StartWorkflowRequest(string Name)
{
    public const string Route = "/Workflow/Start";
}