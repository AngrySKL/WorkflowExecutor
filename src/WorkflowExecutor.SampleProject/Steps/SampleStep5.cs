﻿using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowExecutor.SampleProject.Steps;

public class SampleStep5 : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Serilog.Log.Logger.Information($"==== Executing {nameof(SampleStep5)} ====");

        return ExecutionResult.Next();
    }
}
