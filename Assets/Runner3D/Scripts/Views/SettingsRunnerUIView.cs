﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Runner3D.Scripts.Views
{
    public class SettingsRunnerUIView : UIView
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Slider volumeSlider;
        [SerializeField] private Toggle audioToggle;

        public override string ViewName => nameof(SettingsRunnerUIView);

        private void Start()
        {
            Initialize();

            var sm = GameContext.Instance.SaveService.Load<SettingModel>();

            volumeSlider.value = sm.volume;
            volumeSlider.minValue = 0;
            volumeSlider.maxValue = 1;
            audioToggle.isOn = sm.mute;
            
            backButton.onClick.AddListener(() => GameContext.Instance.ShowView(nameof(MenuRunnerUIView)));
            
            volumeSlider.onValueChanged.AddListener(v =>
            {
                GameContext.Instance.AudioService.Volume = v;
                var settingsModel = GameContext.Instance.SaveService.Load<SettingModel>();
                settingsModel.volume = v;
                GameContext.Instance.SaveService.Write(settingsModel);
            });
            
            audioToggle.onValueChanged.AddListener(v =>
            {
                GameContext.Instance.AudioService.Mute = v;
                var settingsModel = GameContext.Instance.SaveService.Load<SettingModel>();
                settingsModel.mute = v;
                GameContext.Instance.SaveService.Write(settingsModel);
            });
        }
    }
}