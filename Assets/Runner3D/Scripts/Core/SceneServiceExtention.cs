using Core.Services.Interfaces;

using UnityEngine;

namespace Runner3D.Scripts.Core
{
    public static class SceneServiceExtention
    {
        public static AsyncOperation LoadLevelScene(this ISceneService self, int levelNumber)
        {
            return self.LoadScene($"Level_{levelNumber}");
        }

        public static void UnLoadLevelScene(this ISceneService self, int levelNumber)
        {
            self.UnloadScene($"Level_{levelNumber}");
        }
    }
}