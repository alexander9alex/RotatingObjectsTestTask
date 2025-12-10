namespace Code.BaseInfrastructure.Installers
{
  using Common.Services.Data;
  using CoroutineRunner;
  using Gameplay.Features.Input.Service;
  using Gameplay.Features.Selecting.Services;
  using Loading;
  using States.Factory;
  using States.StateMachine;
  using States.States;
  using UI.Factory;
  using UI.Services;
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

    private void BindFactories()
    {
      Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
      Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();
    }

    private void BindServices()
    {
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
      Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
      Container.Bind<IDataService>().To<DataService>().AsSingle();
      Container.Bind<IWindowService>().To<WindowService>().AsSingle();
      Container.Bind<ISelectObjectService>().To<SelectObjectService>().AsSingle();
      Container.Bind<IInputService>().To<InputService>().AsSingle();
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
