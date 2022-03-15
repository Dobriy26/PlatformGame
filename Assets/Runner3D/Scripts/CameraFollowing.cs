using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{ 
    [SerializeField]
    private Transform target;

    [SerializeField] 
    private Vector3 _offset;
    
    void Start()
    {
        _offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + _offset;
    }
}
