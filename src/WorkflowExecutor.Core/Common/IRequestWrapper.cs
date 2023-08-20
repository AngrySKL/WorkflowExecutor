using Ardalis.Result;
using MediatR;

namespace WorkflowExecutor.Core.Common;

public interface IRequestWrapper<TResponse> : IRequest<Result<TResponse>> { }
