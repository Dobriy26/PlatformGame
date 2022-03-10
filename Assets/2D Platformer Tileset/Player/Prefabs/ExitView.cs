using System;
using UnityEngine;
using _2D_Platformer_Tileset.Player.Scripts;

namespace _2D_Platformer_Tileset.Player.Prefabs
{
    public class ExitView : MonoBehaviour
    {
        public event Action OnPlayerExit;
        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerView = other.gameObject.GetComponent<PlayerView>();
            if (playerView != null)
            {
                OnPlayerExit?.Invoke();
            }
        }
    }
}