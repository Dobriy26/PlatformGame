using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common.Scripts.Services;
using Common.Scripts.Services.Abstract;
using Core.Services;
using Core.Services.Interfaces;
using Runner3D.Scripts;
using Runner3D.Scripts.Service;
using Runner3D.Scripts.Views;
using UnityEngine;
using UnityEngine.UIElements;
using AudioService = Core.Services.AudioService;



public class GameContext : MonoBehaviour, IGameContext
{
  
  private UIView _currentView;
  
  public static IGameContext Instance;
  
  public IAudioService AudioService { get; private set; }
  
  public ISaveService SaveService { get; private set; }
  
  public ISceneService SceneService { get; private set; }
  public void ShowView(string viewName)
  {
    var tweener = _currentView.Hide();
    tweener.onComplete += () =>
    {
      _currentView = Views.First(v => v.ViewName == viewName);
      _currentView.Show();
    };
  }

  public void HideView()
  {
    _currentView.Hide();
  }

  [SerializeField] 
  private Sound[] sounds;
  
  [SerializeField]
  private UIView[] Views;

  private void Awake()
  {
    foreach (var sound in sounds)
    {
      sound.source = gameObject.AddComponent<AudioSource>();
      sound.source.clip = sound.clip;
      sound.source.loop = sound.loop;
      sound.source.pitch = sound.pitch;
    }
    AudioService = new AudioService(sounds) ;
    SaveService = new SaveService();
    SceneService = new SceneService();
    
    CheckModels();
    
    if (Instance == null)
    {
      Instance = this;
    }
  }

  private void CheckModels()
  {
    var progressModel = SaveService.Load<ProgressModel>();
    if (progressModel == null)
    {
      progressModel = new ProgressModel();
      SaveService.Write(progressModel);
    }
    
    var settingModel = SaveService.Load<SettingModel>();
    if (settingModel == null)
    {
      settingModel = new SettingModel();
      SaveService.Write(settingModel);
    }
  }
  
  
  
  private void Start()
  {
    _currentView = Views.First(v => v.ViewName == nameof(MenuRunnerUIView));
    _currentView.Show();
  }
  
}

