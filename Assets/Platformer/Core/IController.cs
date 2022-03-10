using System;

namespace Platformer.Core
{
    public enum GameState
    {
        MainMenu,
        PlayLevel,
        TransitionLevel,
        GameOver
    }
    
    public interface IController
    {
        event Action<GameState> OnControllerFinish;

        void Run();
    }
}