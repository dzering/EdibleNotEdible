namespace CodeBase.Infrastructure
{
    public interface IState : IExitState
    {
        void Enter();
    }
}