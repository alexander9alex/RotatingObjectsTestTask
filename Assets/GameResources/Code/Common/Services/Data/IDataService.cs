namespace Code.Common.Services.Data
{
  using UI.Data;
  using UnityEngine;

  public interface IDataService
  {
    void LoadAll();
    GameObject GetWindowPrefab(WindowId windowId);
  }
}