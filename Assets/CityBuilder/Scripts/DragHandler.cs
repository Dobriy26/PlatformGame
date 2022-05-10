using System.Collections;
using System.Collections.Generic;
using CityBuilder.Scripts;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour
{
    [SerializeField] private Camera cameraMain;
    private DraggableView _draggableView;
    private bool _isDragging;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isDragging = IsMouseInDraggableView(out _draggableView);
            if (_isDragging)
            {
                Debug.Log("Dragging Start");
            }

            
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_isDragging)
            {
                _isDragging = false;
                _draggableView = null;
                Debug.Log("Dragging end");
            }
        }

        if (Input.GetMouseButton(0) && _isDragging)
        {
            _draggableView.transform.position = ComeToWorld();
            
            if (Input.GetMouseButtonDown(1))
            {
                DoRotate();
            }
        }
        
    }

    private bool IsMouseInDraggableView(out DraggableView draggableView)
    {
        var ray = cameraMain.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
           return hit.transform.gameObject.TryGetComponent<DraggableView>(out draggableView);
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
}
