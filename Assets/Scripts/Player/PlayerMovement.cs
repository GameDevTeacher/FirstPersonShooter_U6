using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravity = -13f;
    [SerializeField] private float jumpSpeed = 3f;
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] [Range(0.0f, 0.5f)] private float moveSmoothTime = 0.3f;
            
    private float _velocityY;
    
    private Vector2 _currentDirection = Vector2.zero;
    private Vector2 _currentDirectionVelocity = Vector2.zero;

    private CharacterController _characterController;

    private void Start() => _characterController = GetComponent<CharacterController>();
    
    public void UpdateMovement(Vector2 direction, bool jumpPressed)
    {
       if (_characterController.isGrounded)
       {
           _velocityY = -2f;
       }

       _currentDirection = Vector2.SmoothDamp(_currentDirection, direction, ref _currentDirectionVelocity, moveSmoothTime);
       
       if (_characterController.isGrounded && jumpPressed)
       {
           _velocityY = Mathf.Sqrt(jumpSpeed * -2f * gravity);
       }
       
       _velocityY += gravity * Time.deltaTime;
            
       var velocity = (transform.forward * _currentDirection.y + transform.right * _currentDirection.x) 
           * moveSpeed + Vector3.up * _velocityY;

       _characterController.Move(velocity * Time.deltaTime);
    }
}