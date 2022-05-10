using UnityEngine;

namespace CityBuilder.Scripts.Interface
{
    public interface IDraggable
    {
        bool IsDraggable { get; set; }
        Transform Transform { get; }
    }
}