using UnityEngine;

[RequireComponent(typeof(InputActions), typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    private InputActions _input;
    private PlayerMovement _playerMovement;
    private PlayerCamera _playerCamera;

    private void Start()
    {
        _input = GetComponent<InputActions>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerCamera = GetComponent<PlayerCamera>();
    }

    private void Update()
    {
        _playerMovement.UpdateMovement(_input.MoveDirection, _input.JumpPressed);
        _playerCamera.UpdateLookDirection(_input.LookDirection);
    }
}