using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowExecutor.SampleProject.Hardware.Contract;

namespace WorkflowExecutor.SampleProject.Steps;

public class SampleStep2 : StepBody
{
    private readonly IPiette _piette;

    public SampleStep2(IPiette piette)
    {
        _piette = piette;
    }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Serilog.Log.Logger.Information($"==== Executing {nameof(SampleStep2)} ====");

        _piette.Suck();
        _piette.Spit();

        return ExecutionResult.Next();
    }
}
