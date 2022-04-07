using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class TouchController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    
    private Vector3 _touchStart;
    private const int leftCameraLimit = -50;
    private const int rightCameraLimit = 50;
    private Vector3 GetWorldPosition()
    {
        var mousePos = mainCamera.ScreenPointToRay(Input.mousePosition);
        var ground = new Plane(Vector3.forward,Vector3.zero);
        ground.Raycast(mousePos, out var dist);
        return mousePos.GetPoint(dist);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _touchStart = GetWorldPosition();
        }

        if (Input.GetMouseButton(0))
        {
            var direction = _touchStart - GetWorldPosition();
            mainCamera.transform.position += new Vector3(direction.x, 0, 0);
            
        }

        var x = mainCamera.transform.position.x;
        x = Math.Min(x, rightCameraLimit);
        x = Math.Max(x, leftCameraLimit);
        mainCamera.transform.position = new Vector3(x, mainCamera.transform.position.y, mainCamera.transform.position.z);
    }
}
