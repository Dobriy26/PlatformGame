using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathModel : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    public List<(Vector3, Vector3)> Ways;

    private void Awake()
    {
        Ways = new List<(Vector3, Vector3)>();
        for (int i = 0; i < points.Length-1; i++)
        {
            Ways.Add((points[i].transform.position, points[i+1].transform.position));
        }
    }
}
