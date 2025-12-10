namespace Code.UI.Windows
{
  using Common.Services.Data;
  using Data;
  using Gameplay.Features.Selecting.Services;
  using UnityEngine;
  using UnityEngine.UI;
  using Zenject;

  public class ObjectDescriptionMenu : BaseWindow
  {
    [SerializeField] private Text _description;

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
      Id = WindowId.ObjectDescriptionMenu;

      if (_selectObjectService.SelectedObjectId != null)
        _description.text = _data.GetObjectConfig(_selectObjectService.SelectedObjectId.Value).Description;
    }
  }
}
