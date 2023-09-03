namespace WorkflowExecutor.Infrastructure.Requests;

public record ProjectStepNamesRequest(string ProjectName)
{
    public const string Route = "/Project/{ProjectName}/Steps";

    public static string BuildRoute(string projectName) => Route.Replace("{ProjectName}", projectName);
}
