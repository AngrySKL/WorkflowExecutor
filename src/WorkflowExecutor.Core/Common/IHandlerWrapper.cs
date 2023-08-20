using Ardalis.Result;
using MediatR;

namespace WorkflowExecutor.Core.Common;

public interface IHandlerWrapper<in TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
    where TRequest : IRequestWrapper<TResponse>
{ }