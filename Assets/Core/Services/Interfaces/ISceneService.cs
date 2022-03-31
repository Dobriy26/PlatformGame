using System.Collections.Generic;
using UnityEngine;

namespace Core.Services.Interfaces
{
    public interface ISceneService
    {
        AsyncOperation LoadScene(string name);
        AsyncOperation UnloadScene(string name);
        bool IsLoading { get; }
        IEnumerable<GameObject> GetActiveRoots();
    }

   
}