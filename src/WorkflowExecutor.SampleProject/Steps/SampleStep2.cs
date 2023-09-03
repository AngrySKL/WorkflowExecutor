using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowExecutor.SampleProject.Steps;

public class SampleStep2 : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Console.WriteLine($"==== Executing {nameof(SampleStep2)} ====");

        return ExecutionResult.Next();
    }
}
