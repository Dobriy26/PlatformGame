using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TileView : MonoBehaviour
{
   /* private Renderer _renderer;
    private Color _currentColor = Color.white;
    private bool CheckMouseHover()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            return ReferenceEquals(hit.transform.gameObject, gameObject);
        }

        return false;
    }

    private void Awake()
    {
        _renderer = GetComponentInChildren<Renderer>();
        
    }

    private void Update()
    {
        var color = CheckMouseHover() ? Color.red : Color.white;
        if (_currentColor == color)
        {
            return;
        }

        _currentColor = color;
        _renderer.material.DOColor(color, 0.5f);
       
    }*/
   
}
