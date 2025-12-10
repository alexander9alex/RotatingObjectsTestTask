namespace Code.UI.Factory
{
  using Windows;
  using Common.Services.Data;
  using Data;
  using UnityEngine;
  using Zenject;

  public class WindowFactory : IWindowFactory
  {
    private readonly IInstantiator _instantiator;
    private readonly IDataService _data;

    public WindowFactory(IInstantiator instantiator, IDataService data)
    {
      _instantiator = instantiator;
      _data = data;
    }

    public TWindow CreateWindow<TWindow>(WindowId windowId) where TWindow : BaseWindow =>
      _instantiator.InstantiatePrefabForComponent<TWindow>(PrefabFor(windowId));

    private GameObject PrefabFor(WindowId windowId) =>
      _data.GetWindowPrefab(windowId);
  }
}
