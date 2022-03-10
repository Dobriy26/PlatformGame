using System;
using System.Collections;
using System.Collections.Generic;
using _2D_Platformer_Tileset.Player.Prefabs;
using _2D_Platformer_Tileset.Player.Scripts;
using Camera;
using Platformer.Core;
using Platformer.Levels;
using Platformer.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MainMenu menu;
    public GameUIView gameUI;
    public GameModel gameModel;
    public List<LevelView> listLevel;
    public PlayerView playerView;
    public CameraFollow cameraFollowing;
    private IController _carnController;

    private void PlayState(GameState gameState)
    {
        if (_carnController != null)
        {
            _carnController.OnControllerFinish -= PlayState;
        }

        switch (gameState)
        {
            case GameState.MainMenu:
                _carnController = new MainMenuController(menu);
                break;
            case GameState.GameOver:
            case GameState.PlayLevel:
                if (gameModel.currentLevel > listLevel.Count)
                {
                    gameModel.currentLevel = 1;
                }

                var currentLevel = listLevel[gameModel.currentLevel - 1];
                _carnController = new LevelController(gameObject, currentLevel, playerView, cameraFollowing, gameUI,
                    gameModel);
                break;
             
        }

        _carnController.OnControllerFinish += PlayState;
        _carnController.Run();
    }

    void Start()
    {
        gameModel.currentLevel = 1;
        PlayState(GameState.MainMenu);
    }
    void Update()
    {
        
    }
}
