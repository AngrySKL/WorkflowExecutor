using System.Reflection;

namespace WorkflowExecutor.Infrastructure;

public static class AssemblyReference
{
    public static Assembly Assembly => LazyAssembly.Value;
    private static readonly Lazy<Assembly> LazyAssembly = new(Assembly.GetExecutingAssembly());
}