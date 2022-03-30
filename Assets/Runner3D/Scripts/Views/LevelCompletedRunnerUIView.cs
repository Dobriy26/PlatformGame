using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runner3D.Scripts.Views
{
    public class LevelCompletedRunnerUIView : UIView
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private Button nextButton;

        [SerializeField] private Text scoreText;
        [SerializeField] private Text timeText;

        public override string ViewName => nameof(LevelCompletedRunnerUIView);

        private void Awake()
        {
            Initialize();
        }
    }
}