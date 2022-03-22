using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioService : MonoBehaviour
{
  [SerializeField]
  private SoundModel[] _sounds;

  private void Awake()
  {
    DontDestroyOnLoad(this);
    foreach (var sound in _sounds)
    {
      sound.source = gameObject.AddComponent<AudioSource>();
      sound.source.clip = sound.clip;
      sound.source.volume = sound.volume;
      sound.source.pitch = sound.pitch;
      sound.source.loop = sound.loop;
    }
  }

  public void PlayMusic(string name)
  {
    var sound = _sounds.FirstOrDefault(model => model.name == name);
    if (sound == null)
    {
      Debug.Log($"This sound {name} not found");
      return;
    }
    if (sound.source.isPlaying == enabled)
    {
      sound.source.Pause();
    }
    else
    {
      sound.source.Play();
    }
  }
}
