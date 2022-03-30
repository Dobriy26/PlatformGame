using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Runner3D.Scripts.Views
{
    public class MenuRunnerUIView : UIView
    {
        [SerializeField] 
         private Button playButton;
        [SerializeField] 
        private Button exitButton;
        [SerializeField] 
        private Button settingsButton;
        public override string ViewName => nameof(MenuRunnerUIView);

        private void Awake()
        {
            Initialize();
           
            playButton.onClick.AddListener(PlayLevel);
            settingsButton.onClick.AddListener(() => GameContext.Instance.ShowView(nameof(SettingsRunnerUIView)));
            
            exitButton.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }

        private void PlayLevel()
        {
           var pm = GameContext.Instance.SaveService.Load<ProgressModel>();
           var asyncOperation = GameContext.Instance.SceneService.LoadScene($"Level_{pm.currentLevel}");
           asyncOperation.completed += operation =>
           {
                GameContext.Instance.HideView();
           };
        }
    }
}