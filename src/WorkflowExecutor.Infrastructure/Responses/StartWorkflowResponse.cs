using WorkflowExecutor.Infrastructure.Records;

namespace WorkflowExecutor.Infrastructure.Responses
{
    public class StartWorkflowResponse
    {
        public StartWorkflowResponse(WorkflowRecord workflow)
        {
            Workflow = workflow;
        }

        public WorkflowRecord Workflow { get; set; }
    }
}