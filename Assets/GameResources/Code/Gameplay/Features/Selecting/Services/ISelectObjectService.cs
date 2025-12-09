namespace Code.Gameplay.Features.Selecting.Services
{
  using System;
  using Data;

  public interface ISelectObjectService
  {
    event Action onSelectedObjectChanged;
    event Action onObjectUnselected;
    ObjectId SelectedObjectId { get; }
    void SelectObject(ObjectId objectId);
    void UnselectObject();
  }
}
