namespace Code.Gameplay.Features.Rotation.Services
{
  using System;
  using Input.Service;
  using Selecting.Services;
  using UnityEngine;

  public class RotateObjectService : IRotateObjectService
  {
    private const float ROTATION_SPEED = 0.2f;

    public event Action<Vector2> onRotateObject;

    private readonly IInputService _inputService;
    private readonly ISelectObjectService _selectObjectService;

    private bool _canRotate;
    private Camera _camera;

    public RotateObjectService(IInputService inputService, ISelectObjectService selectObjectService)
    {
      _inputService = inputService;
      _selectObjectService = selectObjectService;

      _inputService.onClickStarted += StartRotation;
      _inputService.onClickEnded += EndRotation;
      _inputService.onMousePositionDeltaChanged += Rotate;
    }

    ~RotateObjectService()
    {
      _inputService.onClickStarted -= StartRotation;
      _inputService.onClickEnded -= EndRotation;
      _inputService.onMousePositionDeltaChanged -= Rotate;
    }

    public void SetCamera(Camera camera) =>
      _camera = camera;

    private void StartRotation() =>
      _canRotate = CanRotate();

    private void EndRotation() =>
      _canRotate = false;

    private void Rotate()
    {
      if (_canRotate)
        _selectObjectService.SelectedObject.transform.Rotate(GetRotationVector(), Space.World);
    }

    private bool CanRotate() =>
      Physics.Raycast(_camera.ScreenPointToRay(_inputService.MousePosition), out RaycastHit hit)
      && hit.collider.gameObject == _selectObjectService.SelectedObject;

    private Vector3 GetRotationVector() =>
      new Vector3(_inputService.MousePositionDelta.y, -_inputService.MousePositionDelta.x, 0) * ROTATION_SPEED;
  }
}
