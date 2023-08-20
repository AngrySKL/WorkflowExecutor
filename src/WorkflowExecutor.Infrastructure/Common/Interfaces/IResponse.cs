﻿namespace WorkflowExecutor.Infrastructure.Common.Interfaces
{
    public interface IResponse<T>
    {
        T Data { get; }
        List<string> Errors { get; }
        bool Succeeded { get; }
    }
}
