namespace Code.Gameplay.Features.Rotation.Services
{
  using System;
  using UnityEngine;

  public interface IRotateObjectService
  {
    event Action<Vector2> onRotateObject;
    void SetCamera(Camera camera);
  }
}
