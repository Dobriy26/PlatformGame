using System;
using CityBuilder.Scripts.Core;
using CityBuilder.Scripts.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace CityBuilder.Scripts
{
    public class BuildingSaveSystem : MonoBehaviour
    {
        [SerializeField] private Button saveButton;
        [SerializeField] private Button loadButton;
        [SerializeField] private InputField inputFieldName;
        private BuildingView _buildingView;
        private ISaveService _saveService = new SaveService();

        private void Awake()
        {
            _buildingView = GetComponentInChildren<BuildingView>();
        }

        private void Start()
        {
            saveButton.onClick.AddListener(Save);
            loadButton.onClick.AddListener(Load);
        }

        private void Save()
        {
            var s = new BuildingSaveModel();
            s.name = inputFieldName.text;
            s.mesh = _buildingView.MeshFilter.mesh;
            s.material = _buildingView.Renderer.material;
            _saveService.Write(s, nameof(BuildingSaveModel) + s.name);
            
        }

        private void Load()
        {
            var model = _saveService.Load<BuildingSaveModel>(nameof(BuildingSaveModel) + inputFieldName.text);
            _buildingView.MeshFilter.mesh = model.mesh;
            _buildingView.Renderer.material = model.material;
            

        }
    }
}