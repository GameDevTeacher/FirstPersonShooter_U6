using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerMovement _playerMovement;
    private PlayerCamera _playerCamera;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerCamera = GetComponent<PlayerCamera>();
    }

    private void Update()
    {
        _playerMovement.UpdateMovement(_playerInput.MoveDirection, _playerInput.JumpPressed);
        _playerCamera.UpdateLookDirection(_playerInput.LookDirection);
    }
}