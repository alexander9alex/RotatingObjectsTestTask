namespace Code.Gameplay.Features.Selecting.Services
{
  using System;
  using Data;

  public class SelectObjectService : ISelectObjectService
  {
    public event Action onSelectedObjectChanged = delegate {};
    public event Action onObjectUnselected = delegate {};
    public ObjectId SelectedObjectId { get; private set; }

    public void SelectObject(ObjectId objectId)
    {
      if (SelectedObjectId != objectId)
      {
        SelectedObjectId = objectId;
        onSelectedObjectChanged();
      }
    }

    public void UnselectObject()
    {
      SelectedObjectId = ObjectId.Unknown;
      onObjectUnselected();
    }
  }
}
