using UnityEngine;

namespace CityBuilder.Scripts
{
    [CreateAssetMenu(fileName = "MaterialsAndMeshesList", menuName = @"ScriptableObject\MaterialsAndMeshesList", order = 0)]
    public class MaterialsAndMeshesList : ScriptableObject
    {
        public Material[] materials;
        public Mesh[] meshes;
        
    }
}