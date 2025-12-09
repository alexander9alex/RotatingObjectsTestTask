namespace Code.UI.Services
{
  using Windows;
  using Data;

  public interface IWindowService
  {
    TWindow OpenWindow<TWindow>(WindowId windowId) where TWindow : BaseWindow;
    void CloseWindow(WindowId windowId);
  }
}
