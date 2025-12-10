namespace Code.BaseInfrastructure.States.States
{
  using Gameplay.Features.Rotation.Services;
  using Loading;
  using StateInfrastructure;
  using StateMachine;
  using UI.Data;
  using UI.Services;
  using UI.Windows;
  using UnityEngine;

  public class LoadGameState : IState
  {
    private const string GAME_SCENE = "Game";

    private readonly IGameStateMachine _gameStateMachine;
    private readonly ISceneLoader _sceneLoader;
    private readonly IWindowService _windowService;
    private readonly IRotateObjectService _rotateObjectService;

    public LoadGameState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, IWindowService windowService, IRotateObjectService rotateObjectService)
    {
      _gameStateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
      _windowService = windowService;
      _rotateObjectService = rotateObjectService;
    }

    public void Enter() =>
      _sceneLoader.LoadScene(GAME_SCENE, OnSceneLoaded);

    public void Exit()
    {
    }

    private void OnSceneLoaded()
    {
      _windowService.OpenWindow<HUD>(WindowId.HUD);
      _rotateObjectService.SetCamera(Camera.main);
      _gameStateMachine.Enter<GameLoopState>();
    }
  }
}
