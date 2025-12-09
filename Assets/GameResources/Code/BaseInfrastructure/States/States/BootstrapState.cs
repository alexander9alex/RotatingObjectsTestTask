namespace Code.BaseInfrastructure.States.States
{
  using StateInfrastructure;
  using StateMachine;
  using UnityEngine;

  public class BootstrapState : IState
  {
    private readonly IGameStateMachine _gameStateMachine;

    public BootstrapState(IGameStateMachine gameStateMachine) =>
      _gameStateMachine = gameStateMachine;

    private const int TARGET_FRAME_RATE = 60;

    public void Enter()
    {
      Application.targetFrameRate = TARGET_FRAME_RATE;
      
      _gameStateMachine.Enter<LoadGameState>();
    }

    public void Exit()
    {
    }
  }
}
