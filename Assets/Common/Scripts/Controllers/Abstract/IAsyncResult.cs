using System;

namespace Common.Scripts.Controllers.Abstract
{
    public interface IAsyncResult<out TResult>
    {
        bool IsDone { get; }
        TResult Result { get; }

        event Action<TResult> OnCompleted;
    }
}