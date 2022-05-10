using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button ))]
public class MaterialButton : MonoBehaviour
{
   private Material Material;
   private string Name;
   private Action<Material> ClickHandler;
   [SerializeField] private Button button;
   [SerializeField] private Text text;

   public void Init(string name, Material material, Action<Material> clickHandler)
   {
      Name = name;
      Material = material;
      ClickHandler = clickHandler;
      InitInternal();
   }

   private void InitInternal()
   {
      text.text = Name;
      button.onClick.AddListener((() =>
      {
         ClickHandler?.Invoke(Material);
      }));
   }
}
