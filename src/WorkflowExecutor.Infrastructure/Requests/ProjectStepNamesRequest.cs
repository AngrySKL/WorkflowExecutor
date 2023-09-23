using FastEndpoints;
using FluentValidation;

namespace WorkflowExecutor.Infrastructure.Requests;

public record ProjectStepNamesRequest(string ProjectName)
{
    public const string Route = "/Project/{ProjectName}/Steps";

    public static string BuildRoute(string projectName) => Route.Replace("{ProjectName}", projectName);
}

public class ProjectStepNamesRequestValidator : Validator<ProjectStepNamesRequest>
{
    public ProjectStepNamesRequestValidator()
    {
        RuleFor(request => request.ProjectName)
            .NotEmpty()
            .WithMessage("project name could not be empty")
            .NotEqual("123")
            .WithMessage("project name could not be 123");
    }
}