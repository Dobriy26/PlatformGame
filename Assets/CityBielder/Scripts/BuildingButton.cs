using CityBuilder.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CityBuilder.Scripts
{
    public class BuildingButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private DraggableView draggableView;
        [SerializeField] private GameObject root;
        [SerializeField] private DragAndDropSystem.DragAndDropSystem dragAndDropSystem;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            var position = mainCamera.ScreenToWorldPoint(eventData.position);
            var instance = Instantiate(
                draggableView, 
                Vector3.zero, 
                Quaternion.identity, root.transform);
            dragAndDropSystem.AddDraggableAndStart(instance);
            
        }
    }
}