namespace Code.Common.Services.Data
{
  using System.Collections.Generic;
  using System.Linq;
  using UI.Data;
  using UnityEngine;

  public class DataService : IDataService
  {
    private Dictionary<WindowId, WindowConfig> _windowConfigById = new();

    public void LoadAll() =>
      LoadWindowConfigs();

    public GameObject GetWindowPrefab(WindowId windowId) =>
      _windowConfigById[windowId].Prefab;

    private void LoadWindowConfigs() =>
      _windowConfigById = Resources
        .LoadAll<WindowConfig>("Configs/Windows")
        .ToDictionary(x => x.WindowId, x => x);
  }
}
