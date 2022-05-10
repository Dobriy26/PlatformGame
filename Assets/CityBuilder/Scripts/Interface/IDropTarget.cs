using UnityEngine;

namespace CityBuilder.Scripts.Interface
{
    public interface IDropTarget
    {
        bool CanDrop { get; }
        void DragEnter(IDraggable draggable);
        void DragExit(IDraggable draggable);
        void Drop(IDraggable draggable);
        
        Transform Transform { get; }
    }
}