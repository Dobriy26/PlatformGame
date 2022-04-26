using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button ))]
public class MeshButton : MonoBehaviour
{
   private Mesh Mesh;
   private string Name;
   private Action<Mesh> ClickHandler;
   [SerializeField] private Button button;
   [SerializeField] private Text text;

   public void Init(string name, Mesh mesh, Action<Mesh> clickHandler)
   {
      Name = name;
      Mesh = mesh;
      ClickHandler = clickHandler;
      InitInternal();
   }

   private void InitInternal()
   {
      text.text = Name;
      button.onClick.AddListener((() =>
      {
         ClickHandler?.Invoke(Mesh);
      }));
   }
}
