namespace Code.BaseInfrastructure.States.Factory
{
  using StateInfrastructure;
  using Zenject;

  public class StateFactory : IStateFactory
  {
    private readonly DiContainer _diContainer;

    public StateFactory(DiContainer diContainer) =>
      _diContainer = diContainer;

    public IState GetState<TState>() where TState : IState =>
      _diContainer.Resolve<TState>();
  }
}
