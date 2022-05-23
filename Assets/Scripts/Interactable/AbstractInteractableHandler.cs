using System;
using Constants;
using Movement;
using UnityEngine;

namespace Interactable
{
    public abstract class AbstractInteractableHandler : MonoBehaviour

    {
        // True if the collision should start the interaction
        private bool _interactOnCollision = false;

        // WHen _interactOnCollision is set to true, remember where the player clicked
        // If the player clicks again to change direction, disable the interaction  on collision
        private Vector2 _characterDirectionWhenClicked;
        private Camera _mainCamera;

        protected abstract void OnInteract();

        public MainCharacterMovement mainCharacterMovement;

        protected void StopInteraction()
        {
            _interactOnCollision = false;
        }

        void Start()
        {
            _mainCamera = Camera.main;
        }


        private void OnMouseDown()
        {
            _interactOnCollision = true;
            _characterDirectionWhenClicked = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && mainCharacterMovement.CanMoveOnClick() &&
                _characterDirectionWhenClicked != (Vector2) _mainCamera.ScreenToWorldPoint(Input.mousePosition))
            {
                // The user changed direction
                _interactOnCollision = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(Layers.MainCharacterLayer))
            {
                if (_interactOnCollision)
                {
                    OnInteract();
                }
            }
        }

        private void OnMouseEnter()
        {
            CursorManager.Instance.SetStyle(CursorManager.CursorStyle.Pointer);
        }

        private void OnMouseExit()
        {
            CursorManager.Instance.SetStyle(CursorManager.CursorStyle.Default);
        }
    }
}
