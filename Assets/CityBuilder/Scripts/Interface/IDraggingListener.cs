namespace CityBuilder.Scripts.Interface
{
    public interface IDraggingListener
    {
        void DragStarted(IDraggable draggable);
        void DragFinished(IDraggable draggable);
    }
}