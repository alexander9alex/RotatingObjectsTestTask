namespace Code.Gameplay.Features.Input.Service
{
  using System;
  using UnityEngine;
  using UnityEngine.InputSystem;

  public class InputService : IInputService
  {
    public event Action onClickStarted = delegate {};
    public event Action onClickEnded = delegate {};

    public Vector2 MousePosition { get; private set; }
    public Vector2 MousePositionDelta { get; private set; }

    private readonly InputActions _inputActions = new();

    public InputService()
    {
      _inputActions.Controls.Click.started += ClickStarted;
      _inputActions.Controls.Click.canceled += ClickEnded;

      _inputActions.Controls.MousePosition.performed += UpdateMousePosition;
      _inputActions.Controls.MousePositionDelta.performed += UpdateMousePositionDelta;
    }

    ~InputService()
    {
      _inputActions.Controls.Click.started -= ClickStarted;
      _inputActions.Controls.Click.canceled -= ClickEnded;

      _inputActions.Controls.MousePosition.performed -= UpdateMousePosition;
      _inputActions.Controls.MousePositionDelta.performed -= UpdateMousePositionDelta;
    }

    public void EnableInput() =>
      _inputActions.Enable();

    public void DisableInput() =>
      _inputActions.Disable();

    private void ClickStarted(InputAction.CallbackContext context) =>
      onClickStarted();

    private void ClickEnded(InputAction.CallbackContext context) =>
      onClickEnded();

    private void UpdateMousePosition(InputAction.CallbackContext context) =>
      MousePosition = context.ReadValue<Vector2>();

    private void UpdateMousePositionDelta(InputAction.CallbackContext context) =>
      MousePositionDelta = context.ReadValue<Vector2>();
  }
}
