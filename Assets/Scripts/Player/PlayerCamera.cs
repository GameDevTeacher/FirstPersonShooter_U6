using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
   [SerializeField] private Transform playerCamera;
   [SerializeField] private float cursorSensitivity = 3.5f;
   [SerializeField] [Range(0.0f, 0.5f)] private float cursorSmoothTime = 0.03f;
   [SerializeField] private bool lockCursor = true;
   
   private Vector2 _currentCursorDelta = Vector2.zero;
   private Vector2 _currentCursorDeltaVelocity = Vector2.zero;
        
   private float _cameraPitch;
   
   private void Start()
   {
      if (!lockCursor) return;
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
   }

   public void UpdateLookDirection(Vector2 lookDirection)
   {
      _currentCursorDelta = Vector2.SmoothDamp(_currentCursorDelta, lookDirection,
         ref _currentCursorDeltaVelocity, cursorSmoothTime);
            
      _cameraPitch -= _currentCursorDelta.y * cursorSensitivity;

      _cameraPitch = Mathf.Clamp(_cameraPitch, -90, 90);
            
      playerCamera.localEulerAngles = Vector3.right * _cameraPitch;
            
      transform.Rotate(Vector3.up * (_currentCursorDelta.x * cursorSensitivity));
   }
}