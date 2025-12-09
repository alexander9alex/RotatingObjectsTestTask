namespace Code.UI.Buttons
{
  using Windows;
  using Data;
  using Services;
  using UnityEngine;
  using UnityEngine.UI;
  using Zenject;

  public class OpenCloseWindowButton : MonoBehaviour
  {
    [SerializeField] private WindowId _windowId;
    [SerializeField] private bool _openWindow = true;

    private IWindowService _windowService;
    private Button _button;

    [Inject]
    private void Construct(IWindowService windowService) =>
      _windowService = windowService;

    private void Start()
    {
      _button = GetComponent<Button>();
      _button.onClick.AddListener(OpenOrCloseWindow);
    }

    private void OnDestroy() =>
      _button.onClick.RemoveListener(OpenOrCloseWindow);

    private void OpenOrCloseWindow()
    {
      if (_openWindow)
        _windowService.OpenWindow<BaseWindow>(_windowId);
      else
        _windowService.CloseWindow(_windowId);
    }
  }
}
