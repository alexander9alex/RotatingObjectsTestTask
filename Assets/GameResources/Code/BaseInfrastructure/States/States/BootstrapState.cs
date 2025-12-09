namespace Code.BaseInfrastructure.States.States
{
  using Common.Services.Data;
  using StateInfrastructure;
  using StateMachine;
  using UnityEngine;

  public class BootstrapState : IState
  {
    private readonly IGameStateMachine _gameStateMachine;
    private readonly IDataService _data;

    public BootstrapState(IGameStateMachine gameStateMachine, IDataService data)
    {
      _gameStateMachine = gameStateMachine;
      _data = data;
    }

    private const int TARGET_FRAME_RATE = 60;

    public void Enter()
    {
      Application.targetFrameRate = TARGET_FRAME_RATE;
      _data.LoadAll();
      _gameStateMachine.Enter<LoadGameState>();
    }

    public void Exit()
    {
    }
  }
}
