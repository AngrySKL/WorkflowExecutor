using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowExecutor.SampleProject.Steps;

public class SampleStep3 : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Serilog.Log.Logger.Information($"==== Executing {nameof(SampleStep3)} ====");

        return ExecutionResult.Next();
    }
}
