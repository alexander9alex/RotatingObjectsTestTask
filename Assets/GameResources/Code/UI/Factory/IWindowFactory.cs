namespace Code.UI.Factory
{
  using Windows;
  using Data;

  public interface IWindowFactory
  {
    TWindow CreateWindow<TWindow>(WindowId windowId) where TWindow : BaseWindow;
  }
}