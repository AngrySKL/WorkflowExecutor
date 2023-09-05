using WorkflowExecutor.SampleProject.Hardware.Contract;

namespace WorkflowExecutor.SampleProject.Hardware.Implementations;

public class Piette : IPiette
{
    public void Spit()
    {
        Console.WriteLine("**** 开始吐液 ****");
        Thread.Sleep(1000);
        Console.WriteLine("**** 吐液完成 ****");
    }

    public void Suck()
    {
        Console.WriteLine("**** 开始吸液 ****");
        Thread.Sleep(1000);
        Console.WriteLine("**** 吸液完成 ****");
    }
}
