using CodeBase.Factories;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;

namespace CodeBase.Logic
{
    public class LoadLevelState : IState
    {
        private readonly IGameFactory _gameFactory;
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _gameStateMachine;
        private readonly IProgressService _progressService;

        public LoadLevelState(SceneLoader sceneLoader,GameStateMachine gameStateMachine, IGameFactory gameFactory,
            IProgressService progressService)
        {
            _gameFactory = gameFactory;
            _sceneLoader = sceneLoader;
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
        }

        public void Enter()
        {
            _sceneLoader.Load("", OnLoaded);
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }

        private void OnLoaded()
        {
            CreateGameWorld();
        }

        private void CreateGameWorld()
        {
            //_gameFactory.CreateBasket(_basketPositions.Left, _progressService, Criterion.Edible);
           // _gameFactory.CreateBasket(_basketPositions.Right, _progressService, Criterion.NonEdible);
            
            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}