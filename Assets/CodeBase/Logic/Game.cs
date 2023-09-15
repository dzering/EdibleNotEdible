using CodeBase.Infrastructure;
using CodeBase.Infrastructure.States;

namespace CodeBase.Logic
{
    public class Game
    {
        public readonly GameStateMachine GameStateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);
        }
    }
}
