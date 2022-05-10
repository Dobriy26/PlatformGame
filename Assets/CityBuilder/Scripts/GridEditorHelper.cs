using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CityBuilder.Scripts;
using UnityEditor;
using UnityEngine;

public class GridEditorHelper : MonoBehaviour
{
   [Header("Grid")]
   public int rowCount;
   public int columnCount;
   public float sideSize;
   public bool showCoordinates;
   
   
   [Space(10)] 
   public List<TileModel> overrideTiles = new List<TileModel>();
   public TileView defaultTilePrefab;
   
   private void OnDrawGizmos()
   {
      for (int i = 0; i < rowCount; i++)
      {
         for (int j = 0; j < columnCount; j++)
         {
            Debug.DrawLine(GetWorldCoordinateForGizmos(i,j),GetWorldCoordinateForGizmos(i, j+1),Color.green);
            Debug.DrawLine(GetWorldCoordinateForGizmos(i,j),GetWorldCoordinateForGizmos(i+1, j),Color.green);
            if (showCoordinates)
            {
               Handles.Label(GetWorldCoordinates(i,j),$"{i},{j}");
            }
         }
      }
      Debug.DrawLine(GetWorldCoordinateForGizmos(0,columnCount),GetWorldCoordinateForGizmos(rowCount, columnCount),Color.green);
      Debug.DrawLine(GetWorldCoordinateForGizmos(rowCount,0),GetWorldCoordinateForGizmos(rowCount, columnCount),Color.green);
   }
   public Vector3 GetWorldCoordinates(float i, float j)
   {
      return new Vector3(i * sideSize, 0, j * sideSize) + transform.position;
   }

   public Vector3 GetWorldCoordinateForGizmos(float i, float j)
   {
      return new Vector3(i * sideSize, 0, j * sideSize) + transform.position + new Vector3(-sideSize/2,0,-sideSize/2);
   }
   
   public void ClearChildren()
   {
      var child = transform.childCount;
      var index = 0;
      var childTransforms = new GameObject[child];

      foreach (Transform childTransform in transform)
      {
         childTransforms[index] = childTransform.gameObject;
         index++;
      }

      foreach (var childTransform in childTransforms)
      {
         DestroyImmediate(childTransform);
      }
   }

   public TileView GetTilePrefab(int i, int j)
   {
      var tile = overrideTiles.FirstOrDefault(t => t.indexes.x == i && t.indexes.y == j);
      return tile == null ? defaultTilePrefab : tile.TileView;
   }
}
