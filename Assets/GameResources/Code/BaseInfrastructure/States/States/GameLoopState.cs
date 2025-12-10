namespace Code.BaseInfrastructure.States.States
{
  using Gameplay.Features.Input.Service;
  using StateInfrastructure;

  public class GameLoopState : IState
  {
    private readonly IInputService _inputService;

    public GameLoopState(IInputService inputService) =>
      _inputService = inputService;

    public void Enter() =>
      _inputService.EnableInput();

    public void Exit() =>
      _inputService.DisableInput();
  }
}
