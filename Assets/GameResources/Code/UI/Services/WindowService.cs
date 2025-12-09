namespace Code.UI.Services
{
  using System.Collections.Generic;
  using System.Linq;
  using Windows;
  using Data;
  using Factory;
  using UnityEngine;

  public class WindowService : IWindowService
  {
    private readonly IWindowFactory _windowFactory;
    private readonly List<BaseWindow> _spawnedWindows = new();

    public WindowService(IWindowFactory windowFactory) =>
      _windowFactory = windowFactory;

    public TWindow OpenWindow<TWindow>(WindowId windowId) where TWindow : BaseWindow
    {
      TWindow window = _windowFactory.CreateWindow<TWindow>(windowId);
      _spawnedWindows.Add(window);
      return window;
    }

    public void CloseWindow(WindowId windowId)
    {
      BaseWindow window = _spawnedWindows.FirstOrDefault(x => x.Id == windowId);
      _spawnedWindows.Remove(window);
      Object.Destroy(window);
    }
  }
}
