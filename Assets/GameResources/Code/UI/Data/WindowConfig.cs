namespace Code.UI.Data
{
  using UnityEngine;

  [CreateAssetMenu(menuName = "Configs/" + nameof(WindowConfig), fileName = nameof(WindowConfig))]
  public class WindowConfig : ScriptableObject
  {
    public WindowId WindowId;
    public GameObject Prefab;
  }
}
