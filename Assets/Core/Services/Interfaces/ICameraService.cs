using UnityEngine;

namespace Core.Services.Interfaces
{
    public interface ICameraService
    {
        void SetMainCamera(Camera camera);
        void SetDefaultCamera();
    }
}