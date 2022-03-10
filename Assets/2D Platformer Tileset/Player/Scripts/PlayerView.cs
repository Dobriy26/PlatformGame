using UnityEngine;
using System;
using _2D_Platformer_Tileset.Player.Prefabs;

namespace _2D_Platformer_Tileset.Player.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerView : MonoBehaviour
    {
      
        public event Action CoinCollected;

        private void OnTriggerEnter2D(Collider2D col)
        {
            var coin = col.GetComponent<CoinView>();
            if (coin != null)
            {
                Destroy(coin.gameObject); 
                CoinCollected.Invoke();
            }
        }
    }
}