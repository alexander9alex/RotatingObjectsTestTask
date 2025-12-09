namespace Code.UI.Selectors
{
  using System.Collections.Generic;
  using System.Linq;
  using Gameplay.Features.Selecting.Data;
  using Gameplay.Features.Selecting.Services;
  using Toggles;
  using UnityEngine;
  using Zenject;

  public class ObjectSelector : MonoBehaviour
  {
    [SerializeField] private List<SelectObjectToggle> _toggles = new();
    private ISelectObjectService _selectObjectService;

    [Inject]
    public void Construct(ISelectObjectService selectObjectService) =>
      _selectObjectService = selectObjectService;

    private void OnEnable()
    {
      UpdateToggles();
      _toggles.ForEach(x => x.Toggle.onValueChanged.AddListener(OnSelectingObjectChanged));
    }

    private void OnDisable() =>
      _toggles.ForEach(x => x.Toggle.onValueChanged.RemoveListener(OnSelectingObjectChanged));

    private void OnSelectingObjectChanged(bool isSelected)
    {
      SelectObjectToggle toggle = _toggles.FirstOrDefault(x => x.Toggle.isOn);

      if (toggle != null)
        _selectObjectService.SelectObject(toggle.ObjectId);
      else
        _selectObjectService.UnselectObject();
    }

    private void UpdateToggles()
    {
      if (_selectObjectService.SelectedObjectId != ObjectId.Unknown)
        _toggles.Find(x => x.ObjectId == _selectObjectService.SelectedObjectId).Toggle.isOn = true;
    }
  }
}
