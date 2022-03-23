namespace Common.Scripts.Controllers.Abstract
{
    public interface IControllerWithResult<out TResult> : IController
    {
        TResult Result { get; }
    }
}