namespace Code.Gameplay.Features.Selecting.Services
{
  using Data;
  using UnityEngine;

  public interface ISelectObjectService
  {
    GameObject SelectedObject { get; }
    ObjectId? SelectedObjectId { get; }
    void SelectObject(ObjectId? objectId);
  }
}
