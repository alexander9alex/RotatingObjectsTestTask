namespace Code.UI.Selectors
{
  using System.Collections.Generic;
  using System.Linq;
  using Gameplay.Features.Selecting.Data;
  using Gameplay.Features.Selecting.Services;
  using Toggles;
  using UnityEngine;

  public class ObjectSelector : MonoBehaviour
  {
    [SerializeField] private List<SelectObjectToggle> _toggles = new();
    private readonly ISelectObjectService _selectObjectService;

    public ObjectSelector(ISelectObjectService selectObjectService) =>
      _selectObjectService = selectObjectService;

    private void Start() =>
      _toggles.ForEach(x => x.Toggle.onValueChanged.AddListener(OnSelectingObjectChanged));

    private void OnDestroy() =>
      _toggles.ForEach(x => x.Toggle.onValueChanged.RemoveListener(OnSelectingObjectChanged));

    private void OnSelectingObjectChanged(bool isSelected)
    {
      SelectObjectToggle toggle = _toggles.FirstOrDefault(x => x.Toggle.isOn == isSelected);
      if (toggle != null)
        _selectObjectService.SelectObject(toggle.ObjectId);
      else
        _selectObjectService.UnselectObject();
    }
  }
}
