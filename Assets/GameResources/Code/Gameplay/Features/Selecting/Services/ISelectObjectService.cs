namespace Code.Gameplay.Features.Selecting.Services
{
  using System;
  using Data;
  using UnityEngine;

  public interface ISelectObjectService
  {
    event Action onSelectedObjectChanged;
    GameObject SelectedObject { get; }
    ObjectId? SelectedObjectId { get; }
    void SelectObject(ObjectId? objectId);
  }
}
