namespace Code.BaseInfrastructure.States.States
{
  using StateInfrastructure;
  using UnityEngine;

  public class GameLoopState : IState
  {
    public void Enter()
    {
      Debug.Log("Игра запущена!");
    }

    public void Exit()
    {
    }
  }
}
