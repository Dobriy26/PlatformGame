using System.Collections.Generic;
using UnityEngine;

namespace Common.Scripts.Services.Abstract
{
    public interface ISceneService
    {
        AsyncOperation LoadScene(string name);
        AsyncOperation UnloadScene(string name);
        bool IsLoading { get; }
        IEnumerable<GameObject> GetActiveRoots();
    }

   
}