namespace Code.BaseInfrastructure.Installers
{
  using CoroutineRunner;
  using Loading;
  using States.Factory;
  using States.StateMachine;
  using States.States;
  using Zenject;

  public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
  {
    public override void InstallBindings()
    {
      BindFactories();
      BindServices();
      BindGameStates();
      BindGameStateMachine();
      BindGameStarter();
    }

    private void BindFactories() =>
      Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();

    private void BindServices()
    {
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
      Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
    }

    private void BindGameStates()
    {
      Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
      Container.BindInterfacesAndSelfTo<LoadGameState>().AsSingle();
      Container.BindInterfacesAndSelfTo<GameLoopState>().AsSingle();
    }

    private void BindGameStateMachine() =>
      Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();

    private void BindGameStarter() =>
      Container.BindInterfacesAndSelfTo<GameStarter>().AsSingle();
  }
}
