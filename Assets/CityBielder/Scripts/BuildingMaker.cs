using System;
using System.Collections;
using System.Collections.Generic;
using CityBuilder.Scripts;
using UnityEngine;

public class BuildingMaker : MonoBehaviour
{
   [SerializeField] private Material[] materials;
   [SerializeField] private MaterialButton materialButtonPrefab;
   [SerializeField] private Transform materialButtonTarget;
   [SerializeField] private BuildingView buildingView;
   [SerializeField] private Mesh[] meshes;
   [SerializeField] private MeshButton meshButtonPrefab;
   [SerializeField] private Transform meshButtonTarget;

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
      foreach (var mesh in meshes)
      {
         var btn = Instantiate(meshButtonPrefab, meshButtonTarget);
         btn.Init(mesh.name, mesh, OnMeshButtonClick);
      }

      foreach (var material in materials)
      {
         var btn = Instantiate(materialButtonPrefab, materialButtonTarget);
         btn.Init(material.name, material, OnMaterialButtonClick);
      }
   }
}
