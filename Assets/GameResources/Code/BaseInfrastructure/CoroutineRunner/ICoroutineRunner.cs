namespace Code.BaseInfrastructure.CoroutineRunner
{
  using System.Collections;
  using UnityEngine;

  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator coroutine);
  }
}
