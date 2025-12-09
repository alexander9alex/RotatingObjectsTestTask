namespace Code.BaseInfrastructure.States.StateMachine
{
  using Factory;
  using StateInfrastructure;

  public class GameStateMachine : IGameStateMachine
  {
    private readonly IStateFactory _stateFactory;
    private IState _currentState;

    public GameStateMachine(IStateFactory stateFactory) =>
      _stateFactory = stateFactory;

    public void Enter<TState>() where TState : IState
    {
      if (_currentState != null)
        _currentState.Exit();

      _currentState = _stateFactory.GetState<TState>();
      _currentState.Enter();
    }
  }
}
