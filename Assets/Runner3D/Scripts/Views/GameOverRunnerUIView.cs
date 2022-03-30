using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runner3D.Scripts.Views
{
    public class GameOverRunnerUIView : UIView
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;
        
        
        public override string ViewName => nameof(GameOverRunnerUIView);

        private void Awake()
        {
            Initialize();
        }
    }
}