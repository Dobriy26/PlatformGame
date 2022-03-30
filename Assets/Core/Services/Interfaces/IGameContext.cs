using Common.Scripts.Services.Abstract;
using Runner3D.Scripts.Service;


namespace Core.Services.Interfaces
{
    public interface IGameContext
    {
        IAudioService AudioService { get;}
        ISaveService SaveService { get; }
        ISceneService SceneService { get; }

        void ShowView(string viewName);
        void HideView();
    }
}