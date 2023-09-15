using System;
using System.Collections.Generic;
using CodeBase.Factories;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic;

namespace CodeBase.Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExitState> _states;
        private IExitState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, AllServices allServices)
        {
            _states = new Dictionary<Type, IExitState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, allServices),
                [typeof(LoadLevelState)] = new LoadLevelState(sceneLoader,this,
                    allServices.Single<IGameFactory>(), allServices.Single<IProgressService>()
                    )
            };

        }
            
        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IState => 
            _states[typeof(TState)] as TState;
    }
}