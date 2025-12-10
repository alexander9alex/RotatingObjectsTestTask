namespace Code.UI.Windows
{
  using Common.Services.Data;
  using Data;
  using Gameplay.Features.Selecting.Services;
  using UnityEngine;
  using UnityEngine.UI;
  using Zenject;

  public class ObjectParametersMenu : BaseWindow
  {
    [SerializeField] private Text _parameters;

    private ISelectObjectService _selectObjectService;
    private IDataService _data;

    [Inject]
    private void Construct(ISelectObjectService selectObjectService, IDataService data)
    {
      _selectObjectService = selectObjectService;
      _data = data;
    }

    protected override void Initialize()
    {
      Id = WindowId.ObjectParametersMenu;

      if (_selectObjectService.SelectedObjectId != null)
        _parameters.text = _data.GetObjectConfig(_selectObjectService.SelectedObjectId.Value).Parameters;
    }
  }
}
