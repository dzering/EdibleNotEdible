using System;

namespace CodeBase.Infrastructure
{
    public interface ISceneLoader : IService
    {
        void Load(string nextScene, Action onLoaded = null);
    }
}