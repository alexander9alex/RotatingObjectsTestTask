namespace Code.Gameplay.Features.Input.Service
{
  using System;
  using UnityEngine;

  public interface IInputService
  {
    event Action onClickStarted;
    event Action onClickEnded;
    Vector2 MousePosition { get; }
    Vector2 MousePositionDelta { get; }
    void EnableInput();
    void DisableInput();
    event Action onMousePositionDeltaChanged;
  }
}
