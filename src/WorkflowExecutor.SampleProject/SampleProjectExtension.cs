using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Models;
using WorkflowExecutor.SampleProject.Steps;

namespace WorkflowExecutor.SampleProject;

public static class SampleProjectExtension
{
    public static void AddSampleProjectSteps(this IServiceCollection services)
    {
        services.AddTransient<StepBody, SampleStep1>();
        services.AddTransient<StepBody, SampleStep2>();
        services.AddTransient<StepBody, SampleStep3>();
        services.AddTransient<StepBody, SampleStep4>();
        services.AddTransient<StepBody, SampleStep5>();
    }
}
