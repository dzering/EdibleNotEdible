using System;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.SceneLoader
{
    public interface ISceneLoader : IService
    {
        void Load(string nextScene, Action onLoaded = null);
    }
}