using System;
using CodeBase.Factories;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string NEXT_SCENE = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _allServices;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices allServices)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _allServices = allServices;

            RegisterServices();
        }

        private void RegisterServices()
        {
            _allServices.RegisterSingle<IAssetProvider>(new AssetProvider());
            _allServices.RegisterSingle<IService>(new GameFactory(_allServices.Single<IAssetProvider>()));
            _allServices.RegisterSingle<IProgressService>(new ProgressService());
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void Enter()
        {
            _sceneLoader.Load(NEXT_SCENE, EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState>();
        }
    }
}