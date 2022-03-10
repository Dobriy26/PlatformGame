using System;
using Platformer.UI;
using UnityEditor;

namespace Platformer.Core
{
    public class MainMenuController : IController
    {
        public MainMenuController(MainMenu mainMenu)
        {
            _mainMenu = mainMenu;
        }

        public event Action<GameState> OnControllerFinish;

        private readonly MainMenu _mainMenu;

        private void OnStartClick()
        {
            _mainMenu.startButton.onClick.RemoveListener(OnStartClick);
            _mainMenu.gameObject.SetActive(false);
            OnControllerFinish.Invoke(GameState.PlayLevel);
            
        }
        
        public void Run()
        {
            _mainMenu.gameObject.SetActive(true);
            _mainMenu.startButton.onClick.AddListener(OnStartClick);
        }
    }
}