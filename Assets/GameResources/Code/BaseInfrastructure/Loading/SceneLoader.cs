namespace Code.BaseInfrastructure.Loading
{
  using System;
  using System.Collections;
  using CoroutineRunner;
  using UnityEngine;
  using UnityEngine.SceneManagement;

  public class SceneLoader : ISceneLoader
  {
    private ICoroutineRunner _coroutineRunner;
    private AsyncOperation _waitNextScene;

    public void LoadScene(string scene, Action onLoaded = null) =>
      _coroutineRunner.StartCoroutine(LoadSceneCoroutine(scene, onLoaded));

    private IEnumerator LoadSceneCoroutine(string scene, Action onLoaded)
    {
      _waitNextScene = SceneManager.LoadSceneAsync(scene);

      while (!_waitNextScene.isDone)
        yield return null;

      onLoaded?.Invoke();
    }
  }
}
