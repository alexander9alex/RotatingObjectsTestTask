namespace Code.BaseInfrastructure.Loading
{
  using States.StateMachine;
  using States.States;
  using Zenject;

  public class GameStarter : IInitializable
  {
    private readonly IGameStateMachine _gameStateMachine;

    public GameStarter(IGameStateMachine gameStateMachine) =>
      _gameStateMachine = gameStateMachine;

    public void Initialize() =>
      _gameStateMachine.Enter<BootstrapState>();
  }
}
