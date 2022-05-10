using UnityEditor;
using UnityEngine;

namespace CityBuilder.Scripts
{
    [CustomEditor(typeof(GridEditorHelper))]
    public class GenerateGridButton : Editor
    {
        public override void OnInspectorGUI()//вызывается в каждый кадр для рисовки.
        {
            DrawDefaultInspector();
            if (GUILayout.Button("GenerateGrid"))
            {
                var gridEditorHelper = (GridEditorHelper)target;
                gridEditorHelper.ClearChildren();
                for (int i = 0; i < gridEditorHelper.rowCount; i++)
                {
                   
                    for (int j = 0; j < gridEditorHelper.columnCount; j++)
                    {
                        
                        var tile = Instantiate(gridEditorHelper.GetTilePrefab(i,j), 
                            gridEditorHelper.GetWorldCoordinates(i, j),
                            Quaternion.identity,gridEditorHelper.transform);
                        tile.name = $"{gridEditorHelper.defaultTilePrefab.name} [{i},{j}]";
                    }
                }
                
            }

            if (GUILayout.Button("Clear"))
            {
                var gridEditorHelper = (GridEditorHelper)target;
                gridEditorHelper.ClearChildren();
            }
        }
    }
}