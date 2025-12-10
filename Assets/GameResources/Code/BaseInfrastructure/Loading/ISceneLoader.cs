namespace Code.BaseInfrastructure.Loading
{
  using System;

  public interface ISceneLoader
  {
    void LoadScene(string scene, Action onLoaded = null);
  }
}