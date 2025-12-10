namespace Code.Common.Services.Data
{
  using System.Collections.Generic;
  using System.Linq;
  using Gameplay.Features.Selecting.Data;
  using UI.Data;
  using UnityEngine;

  public class DataService : IDataService
  {
    private Dictionary<WindowId, WindowConfig> _windowConfigById = new();
    private Dictionary<ObjectId, ObjectConfig> _objectConfigById = new();

    public void LoadAll()
    {
      LoadWindowConfigs();
      LoadObjectConfigs();
    }

    public GameObject GetWindowPrefab(WindowId windowId) =>
      _windowConfigById[windowId].Prefab;

    public ObjectConfig GetObjectConfig(ObjectId objectId) =>
      _objectConfigById[objectId];

    private void LoadWindowConfigs() =>
      _windowConfigById = Resources
        .LoadAll<WindowConfig>("Configs/Windows")
        .ToDictionary(x => x.WindowId, x => x);

    private void LoadObjectConfigs() =>
      _objectConfigById = Resources
        .LoadAll<ObjectConfig>("Configs/Objects")
        .ToDictionary(x => x.ObjectId, x => x);
  }
}
