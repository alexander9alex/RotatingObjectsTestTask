namespace Code.Gameplay.Features.Selecting.Data
{
  using UnityEngine;

  [CreateAssetMenu(menuName = "Configs/" + nameof(ObjectConfig), fileName = nameof(ObjectConfig))]
  public class ObjectConfig : ScriptableObject
  {
    public ObjectId ObjectId;
    public GameObject Prefab;
  }
}
