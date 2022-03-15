using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class GameOver : MonoBehaviour
{
   [SerializeField] private Transform player;
   [SerializeField] private GameObject _gameOver;
   private bool _isGameOver = false;
   private void Update()
   {
      if (player.position.y < -50 && !_isGameOver)
      {
         _gameOver.SetActive(true);
         player.gameObject.SetActive(false);
         Destroy(player);
         _isGameOver = true;
      }
   }
}
