using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowExecutor.SampleProject.Steps;

public class SampleStep1 : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Serilog.Log.Logger.Information($"==== Executing {nameof(SampleStep1)} ====");

        return ExecutionResult.Next();
    }
}
