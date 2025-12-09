namespace Code.BaseInfrastructure.States.States
{
  using Loading;
  using StateInfrastructure;
  using StateMachine;
  using UI.Data;
  using UI.Services;
  using UI.Windows;

  public class LoadGameState : IState
  {
    private const string GAME_SCENE = "Game";

    private readonly IGameStateMachine _gameStateMachine;
    private readonly ISceneLoader _sceneLoader;
    private readonly IWindowService _windowService;

    public LoadGameState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, IWindowService windowService)
    {
      _gameStateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
      _windowService = windowService;
    }

    public void Enter() =>
      _sceneLoader.LoadScene(GAME_SCENE, OnSceneLoaded);

    public void Exit()
    {
    }

    private void OnSceneLoaded()
    {
      _windowService.OpenWindow<HUD>(WindowId.HUD);
      _gameStateMachine.Enter<GameLoopState>();
    }
  }
}
