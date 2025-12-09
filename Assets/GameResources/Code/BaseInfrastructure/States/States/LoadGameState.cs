namespace Code.BaseInfrastructure.States.States
{
  using Loading;
  using StateInfrastructure;
  using StateMachine;

  public class LoadGameState : IState
  {
    private const string GAME_SCENE = "Game";

    private readonly IGameStateMachine _gameStateMachine;
    private readonly ISceneLoader _sceneLoader;

    public LoadGameState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader)
    {
      _gameStateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
    }

    public void Enter() =>
      _sceneLoader.LoadScene(GAME_SCENE, OnSceneLoaded);

    public void Exit()
    {
    }

    private void OnSceneLoaded() =>
      _gameStateMachine.Enter<GameLoopState>();
  }
}
