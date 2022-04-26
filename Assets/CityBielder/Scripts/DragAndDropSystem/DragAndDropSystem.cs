using System.Collections.Generic;
using System.Linq;
using CityBuilder.Scripts;
using CityBuilder.Scripts.Core;
using CityBuilder.Scripts.Interface;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

namespace CityBuilder.Scripts.DragAndDropSystem
{
    public class DragAndDropSystem : MonoBehaviour
    {
        private List<IDraggable> _draggableElements = new List<IDraggable>();
        private List<IDropTarget> _dropTargets = new List<IDropTarget>();
        private List<IDraggingListener> draggingListeners = new List<IDraggingListener>();

        [SerializeField] private Camera cameraMain;
        [SerializeField] private List<GameObject> drugAndDropElements;
        
        private DraggableView _draggableView;
        private IDropTarget _dropTarget;
        private bool _isDragging;

        private void Awake()
        {
            foreach (var element in drugAndDropElements.Where(element => element))
            {
                
                    CheckElement(element);
                
            }

           
        }

        private void StartDragging(DraggableView draggableView)
        {
            _isDragging = true;
            _draggableView = draggableView;
            var mouseWorldPosition = ComeToWorld();
            _draggableView.transform.position = mouseWorldPosition;
            foreach (var dragListener in draggingListeners)
            { 
                dragListener.DragStarted(_draggableView);
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (IsMouseInDraggableView(out var draggableView))
                {
                    StartDragging(draggableView);
                }
        
                    
                    
            }
        
            if (Input.GetMouseButtonUp(0))
            {
                if (_isDragging)
                {
                    CheckDrop();
                    foreach (var dragListener in draggingListeners)
                    {
                        dragListener.DragFinished(_draggableView);
                    }
                    _isDragging = false;
                    _draggableView = null;
                }
            }
        
            if (Input.GetMouseButton(0) && _isDragging) 
            {
                if (_draggableView != null) 
                    _draggableView.transform.position = ComeToWorld();

                if (Input.GetMouseButtonDown(1))
                {
                    DoRotate();
                }
                CheckDropTarget();
            }
                
        }
        
        private bool IsMouseInDraggableView(out DraggableView draggableView)
        {
            var ray = cameraMain.ScreenPointToRay(Input.mousePosition);
            if (Helper.RayCastOnComponent<IDropTarget>(_draggableView.transform.position + Vector3.up, Vector3.down, out var dropTarget))
            {
                var result = dropTarget.Transform.gameObject.TryGetComponent<DraggableView>(out draggableView);
                return result && draggableView.IsDraggable;
            }
        
            draggableView = null;
            return false;
        }
        
        private Vector3 ComeToWorld()
        {
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                cameraMain.WorldToScreenPoint(_draggableView.transform.position).z);
            var worldPosition = cameraMain.ScreenToWorldPoint(position);
            return new Vector3(worldPosition.x, 0, worldPosition.z);
        }
        
        private void DoRotate()
        {
            var rotations = _draggableView.transform.rotation;
            _draggableView.transform.DORotateQuaternion(Quaternion.Euler(rotations.eulerAngles.x, rotations.eulerAngles.y + 90,
                rotations.eulerAngles.z), .5f);
        }
        
        private void CheckElement(GameObject obj)
        {
            FillCollection(obj, draggingListeners);
            FillCollection(obj, _dropTargets);
            FillCollection(obj, _draggableElements);
        }

        private void CheckDropTarget()
        {
            var ray = new Ray(_draggableView.transform.position + Vector3.up, Vector3.down);
            if (Helper.RayCastOnComponent<IDropTarget>(_draggableView.transform.position + Vector3.up, Vector3.down, out var dropTarget))

            {
              
                    if (_dropTarget == null)
                    {
                        _dropTarget = dropTarget;
                        dropTarget.DragEnter(_draggableView);
                    }
                    else if (!_dropTarget.Transform.Equals(dropTarget.Transform))
                    {
                        _dropTarget.DragExit(_draggableView);
                        _dropTarget = dropTarget;
                        _dropTarget.DragEnter(_draggableView);
                        
                    }
               
            }
            else
            {
                _dropTarget?.DragExit(_draggableView);
                _dropTarget = null;
                
            }
            
        }

        private void CheckDrop()
        {
            var ray = new Ray(_draggableView.transform.position, Vector3.down);
            
                if (Helper.RayCastOnComponent<IDropTarget>(_draggableView.transform.position + Vector3.up, Vector3.down, out var dropTarget))
                {
                    if (dropTarget.CanDrop)
                    {
                        dropTarget.Drop(_draggableView);
                        return;
                    }
                    
                   
                }
            

            draggingListeners.Remove(_draggableView);
            DestroyImmediate(_draggableView);
        }

        private void FillCollection<T>(GameObject element, List<T> collection)
        {
            foreach (var componentsInChild in element.GetComponentsInChildren<T>())
            {
                collection.Add(componentsInChild);
            }
            Debug.Log($"collection with {typeof(T).Name} count{collection.Count}");
        }

        public void AddDraggableAndStart(DraggableView draggableView)
        {
            _draggableElements.Add(draggableView);
            draggingListeners.Add(draggableView);
            StartDragging(draggableView);
        }
    }
}