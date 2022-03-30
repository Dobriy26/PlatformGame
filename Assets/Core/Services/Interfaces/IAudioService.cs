using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runner3D.Scripts.Service
{
    public interface IAudioService
    {
        void Play(string soundName);
        void Stop(string soundName);
        float Volume { get; set; }
        
        bool Mute { get; set; }
    }
    
}


