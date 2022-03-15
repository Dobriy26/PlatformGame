using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoredRecorder : MonoBehaviour
{
    private Text text;
    [SerializeField] 
    private Transform player;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = player.position.z.ToString("F");
    }
}
