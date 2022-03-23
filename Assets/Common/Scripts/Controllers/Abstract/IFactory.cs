namespace Common.Scripts.Controllers.Abstract
{
    public interface IFactory<out TResult>
    {
        TResult Create();
    }
}