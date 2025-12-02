using Interaction;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class SelectObject : MonoBehaviour
    {
        [SerializeField] private string selectableTag = "Selectable";
        [SerializeField] private Camera _camera;
        [SerializeField] private Material highlightMaterial;
        [SerializeField] private Material defaultMaterial;
        [SerializeField] private float rayRange;
        
        [SerializeField] private Transform _selection;

        private void OnFire()
        {
            if (_selection == null) return;
            TryGetComponent(out Interactable interact);
            interact.RunInteract();
        }
        
        private void Update()
        {
            if (_selection != null)
            {
                TryGetComponent(out Renderer rend);
                rend.material = defaultMaterial;
              
                _selection = null;
            }
            
            var ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out var hit) && hit.distance < rayRange )
            {
                var selection = hit.transform;

                if (selection.CompareTag(selectableTag))
                {
                    TryGetComponent(out Renderer rend);
                    defaultMaterial = rend.material;
                    
                    if (rend != null)
                    {
                        rend.material = highlightMaterial;
                    }
                    _selection = selection;
                }
            }
        }
    }
}