using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowExecutor.SampleProject.Steps;

public class SampleStep4 : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Console.WriteLine($"==== Executing {nameof(SampleStep4)} ====");

        return ExecutionResult.Next();
    }
}
