namespace Code.Common.Services.Data
{
  using Gameplay.Features.Selecting.Data;
  using UI.Data;
  using UnityEngine;

  public interface IDataService
  {
    void LoadAll();
    GameObject GetWindowPrefab(WindowId windowId);
    ObjectConfig GetObjectConfig(ObjectId objectId);
  }
}