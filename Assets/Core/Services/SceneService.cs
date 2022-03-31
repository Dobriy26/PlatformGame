using System.Collections.Generic;
using Core.Services.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.Scripts.Services
{
    public class SceneService : ISceneService
    {
        private Scene _currentScene;

        public SceneService()
        {
            _currentScene = SceneManager.GetActiveScene();
        }
        
        public AsyncOperation LoadScene(string name)
        {
           var asyncOperation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
           IsLoading = true;
           asyncOperation.completed += operation =>
           {
               var scene = SceneManager.GetSceneByName(name);
               SceneManager.SetActiveScene(scene);
               _currentScene = scene;
               IsLoading = false;
           };
           return asyncOperation;
        }

        public AsyncOperation UnloadScene(string name)
        {
            var asyncOperation = SceneManager.UnloadSceneAsync(name);
            return asyncOperation;
        }

        public bool IsLoading { get; private set; }
        public IEnumerable<GameObject> GetActiveRoots()
        {
           return _currentScene.GetRootGameObjects();
        }
    }
}