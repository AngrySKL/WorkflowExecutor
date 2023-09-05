using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowExecutor.SampleProject.Steps;

namespace WorkflowExecutor.SampleProject;

public static class SampleProjectExtension
{
    public static IServiceCollection AddSampleProjectSteps(this IServiceCollection services)
    {
        services.AddTransient<SampleStep1>();
        services.AddTransient<SampleStep2>();
        services.AddTransient<SampleStep3>();
        services.AddTransient<SampleStep4>();
        services.AddTransient<SampleStep5>();

        services.AddTransient<IStepBody, SampleStep1>();
        services.AddTransient<IStepBody, SampleStep2>();
        services.AddTransient<IStepBody, SampleStep3>();
        services.AddTransient<IStepBody, SampleStep4>();
        services.AddTransient<IStepBody, SampleStep5>();

        return services;
    }
}
