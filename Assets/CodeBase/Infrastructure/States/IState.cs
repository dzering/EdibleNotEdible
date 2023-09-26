namespace CodeBase.Infrastructure.States
{
    public interface IState : IExitState
    {
        void Enter();
    }
}