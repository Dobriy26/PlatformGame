namespace Common.Scripts.Controllers.Abstract
{
    public interface IAsyncFactory<out TResult>
    {
        IAsyncResult<TResult> Create();
    }
}