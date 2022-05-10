using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CityBuilder.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMaker : MonoBehaviour
{
   
   [SerializeField] private MaterialButton materialButtonPrefab;
   [SerializeField] private Transform materialButtonTarget;
   [SerializeField] private BuildingView buildingView;
   [SerializeField] private MeshButton meshButtonPrefab;
   [SerializeField] private Transform meshButtonTarget;
   [SerializeField] private MaterialsAndMeshesList[] palitra;
   [SerializeField] private Dropdown dropdown;
   
   private MaterialsAndMeshesList _currentPalitra;

   private void OnMaterialButtonClick(Material material)
   {
      buildingView.Renderer.material = material;
   }
   
   private void OnMeshButtonClick(Mesh mesh)
   {
      buildingView.MeshFilter.mesh = mesh;
   }

   private void Start()
   {
      var dropDownElements = palitra.Select(p => new Dropdown.OptionData(p.name));
      dropdown.options.AddRange(dropDownElements);
      dropdown.value = 0;
      dropdown.onValueChanged.AddListener(OnPalitraChanged);
      _currentPalitra = palitra[0];
      DrawPalitra();
   }

   private void OnPalitraChanged(int i)
   {
      _currentPalitra = palitra[i];
      ClearPalitra();
      DrawPalitra();
   }

   private void ClearPalitra()
   {
   
      foreach (MaterialButton t in materialButtonTarget.GetComponentsInChildren<MaterialButton>())
      {
         
         DestroyImmediate(t.gameObject);
      }
     
    
      foreach (MeshButton t in meshButtonTarget.GetComponentsInChildren<MeshButton>())
      {
       
         DestroyImmediate(t.gameObject);
      }
     
   }
   private void DrawPalitra()
   {
      
      foreach (var mesh in _currentPalitra.meshes)
      {
         var btn = Instantiate(meshButtonPrefab, meshButtonTarget);
         btn.Init(mesh.name, mesh, OnMeshButtonClick);
      }
      
      foreach (var material in _currentPalitra.materials)
      {
         var btn = Instantiate(materialButtonPrefab, materialButtonTarget);
         btn.Init(material.name, material, OnMaterialButtonClick);
      }

   }
}
