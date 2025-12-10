namespace Code.UI.Buttons
{
  using Gameplay.Features.Selecting.Services;
  using UnityEngine;
  using UnityEngine.UI;
  using Zenject;

  public class InteractiveWhenObjectSelectedButton : MonoBehaviour
  {
    private ISelectObjectService _selectObjectService;
    private Button _button;

    [Inject]
    private void Construct(ISelectObjectService selectObjectService) =>
      _selectObjectService = selectObjectService;

    private void Awake() =>
      _button = GetComponent<Button>();

    private void OnEnable()
    {
      _selectObjectService.onSelectedObjectChanged += UpdateInteractivity;
      UpdateInteractivity();
    }

    private void OnDisable() =>
      _selectObjectService.onSelectedObjectChanged -= UpdateInteractivity;

    private void UpdateInteractivity() =>
      _button.interactable = _selectObjectService.SelectedObjectId != null;
  }
}
