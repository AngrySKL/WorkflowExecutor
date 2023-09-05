using Microsoft.Extensions.DependencyInjection;
using WorkflowExecutor.SampleProject.Hardware.Contract;
using WorkflowExecutor.SampleProject.Hardware.Implementations;

namespace WorkflowExecutor.SampleProject.Hardware;

public static class SampleProjectHardwareExtension
{
    public static IServiceCollection AddSampleProjectHardwares(this IServiceCollection services)
    {
        services.AddTransient<IPiette, Piette>();

        return services;
    }
}
