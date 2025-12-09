namespace Code.Gameplay.Features.Selecting.Spawners
{
  using Common.Services.Data;
  using Data;
  using Services;
  using UnityEngine;
  using Zenject;

  public class SelectingObjectSpawner : MonoBehaviour
  {
    [SerializeField] private Transform _parent;

    private ISelectObjectService _selectObjectService;
    private IDataService _data;

    private GameObject _spawnedObject;

    [Inject]
    private void Construct(ISelectObjectService selectObjectService, IDataService data)
    {
      _selectObjectService = selectObjectService;
      _data = data;
    }

    private void OnEnable()
    {
      _selectObjectService.onSelectedObjectChanged += ChangeSpawnedObject;
      _selectObjectService.onObjectUnselected += DestroySpawnedObject;
    }

    private void OnDisable()
    {
      _selectObjectService.onSelectedObjectChanged -= ChangeSpawnedObject;
      _selectObjectService.onObjectUnselected -= DestroySpawnedObject;
    }

    private void ChangeSpawnedObject()
    {
      DestroySpawnedObject();
      _spawnedObject = Instantiate(PrefabFor(_selectObjectService.SelectedObjectId), _parent);
    }

    private void DestroySpawnedObject()
    {
      if (_spawnedObject != null)
        Destroy(_spawnedObject);
    }

    private GameObject PrefabFor(ObjectId objectId) =>
      _data.GetObjectConfig(objectId).Prefab;
  }
}
