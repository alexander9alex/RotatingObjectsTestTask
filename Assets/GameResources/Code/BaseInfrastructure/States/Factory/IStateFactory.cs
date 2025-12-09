namespace Code.BaseInfrastructure.States.Factory
{
  using StateInfrastructure;

  public interface IStateFactory
  {
    IState GetState<TState>() where TState : IState;
  }
}
