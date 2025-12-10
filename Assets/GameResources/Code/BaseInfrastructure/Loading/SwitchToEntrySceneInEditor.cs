namespace Code.BaseInfrastructure.Loading
{
  using UnityEngine;
  using UnityEngine.SceneManagement;
  using Zenject;

  // Запускается перед всеми остальными скриптами (выставлен Script Execution Order)
  public class SwitchToEntrySceneInEditor : MonoBehaviour
  {
#if UNITY_EDITOR

    private const string ENTRY_SCENE = "Boot";

    private void Awake()
    {
      if (ProjectContext.HasInstance)
        return;

      foreach (GameObject rootObject in gameObject.scene.GetRootGameObjects())
        rootObject.SetActive(false);

      SceneManager.LoadScene(ENTRY_SCENE);
    }

#endif
  }
}
