namespace Code.Gameplay.Features.Selecting.Services
{
  using System;
  using Common.Services.Data;
  using Data;
  using UnityEngine;
  using Object = UnityEngine.Object;

  public class SelectObjectService : ISelectObjectService
  {
    public event Action onSelectedObjectChanged = delegate {};
    public GameObject SelectedObject { get; private set; }
    public ObjectId? SelectedObjectId { get; private set; }

    private readonly IDataService _data;

    public SelectObjectService(IDataService data) =>
      _data = data;

    public void SelectObject(ObjectId? objectId)
    {
      if (SelectedObjectId == objectId)
        return;

      SelectedObjectId = objectId;
      DestroySelectedObject();
      SpawnSelectedObject();
      onSelectedObjectChanged();
    }

    private void DestroySelectedObject()
    {
      if (SelectedObject != null)
        Object.Destroy(SelectedObject);
    }

    private void SpawnSelectedObject()
    {
      if (SelectedObjectId != null)
        SelectedObject = Object.Instantiate(PrefabFor(SelectedObjectId.Value));
    }

    private GameObject PrefabFor(ObjectId objectId) =>
      _data.GetObjectConfig(objectId).Prefab;
  }
}
