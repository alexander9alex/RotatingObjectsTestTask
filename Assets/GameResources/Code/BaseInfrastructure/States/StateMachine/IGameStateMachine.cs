namespace Code.BaseInfrastructure.States.StateMachine
{
  using StateInfrastructure;

  public interface IGameStateMachine
  {
    void Enter<TState>() where TState : IState;
  }
}
