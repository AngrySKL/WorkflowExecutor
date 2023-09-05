using WorkflowExecutor.SampleProject.Hardware.Contract;

namespace WorkflowExecutor.SampleProject.Hardware.Implementations;

public class Piette : IPiette
{
    public void Spit()
    {
        Serilog.Log.Logger.Information("**** 开始吐液 ****");
        Thread.Sleep(1000);
        Serilog.Log.Logger.Information("**** 吐液完成 ****");
    }

    public void Suck()
    {
        Serilog.Log.Logger.Information("**** 开始吸液 ****");
        Thread.Sleep(1000);
        Serilog.Log.Logger.Information("**** 吸液完成 ****");
    }
}
