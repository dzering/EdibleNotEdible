using System;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.States;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.Logic
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        private void Awake()
        {
            _game = new Game(this);
            _game.GameStateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this.gameObject);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}