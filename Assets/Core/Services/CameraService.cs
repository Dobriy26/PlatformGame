using Core.Services.Interfaces;
using UnityEngine;

namespace Core.Services
{
    public class CameraService : ICameraService
    {
        private readonly Camera _defaultCamera;

        private Camera _currentCamera;

        public CameraService(Camera defaultCamera)
        {
            _defaultCamera = defaultCamera;
            _currentCamera = defaultCamera;
        }
        public void SetMainCamera(Camera camera)
        {
            _currentCamera.enabled = false;
            camera.enabled = true;
            _currentCamera = camera;
        }

        public void SetDefaultCamera()
        {
            SetMainCamera(_defaultCamera);
        }
    }
}