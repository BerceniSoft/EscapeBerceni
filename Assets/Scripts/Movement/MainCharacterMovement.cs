using Dialog;
using UnityEngine;

namespace Movement
{
    public class MainCharacterMovement : MonoBehaviour
    {
        public DialogManager dialogManager;
        public bool isMoving;
        
        [SerializeField]
        private float movementSpeed = 3.0f;

        private Rigidbody2D _rigidBody2D;
        private Vector2? _currentTargetPosition;
        
        // If false, mouse movement won't be able to change the target position
        private bool _allowTargetPositionOverride = true;
        private bool _preventMovement;

        private void Start()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }

        public void PauseMovement()
        {
            _preventMovement = true;
            // Delete the current velocity
            // When resumed, the next call to update will set back the velocity
            _rigidBody2D.velocity = new Vector2(0,0);
        }

        public void ResumeMovement()
        {
            _preventMovement = false;
        }

        private void MoveTo(Vector2 destination)
        {
            Vector2 currentPos = transform.position;
            var distance = destination - currentPos;
            // Get the movement velocity vector based on the distance
            // The velocity will gradually decrease this way
            var movement = distance;

            // Consider a distance smaller than an epsilon = 0
            if (Mathf.Abs(movement.x) < 0.05)
            {
                movement.x = 0;
            }

            if (Mathf.Abs(movement.y) < 0.05)
            {
                movement.y = 0;
            }

            if (movement.x == 0 && movement.y == 0)
            {
                // Destination reached          
                isMoving = false;
                _currentTargetPosition = null;

                // Allow mouse movement if it was disabled before
                _allowTargetPositionOverride = true;
            }

            movement.Normalize();
            _rigidBody2D.velocity = movement * movementSpeed;
        }

        public void SetDestination(Vector2 destination, bool allowOverride)
        {
            // We have a destination so we are moving
            isMoving = true;
            _currentTargetPosition = destination;
            _allowTargetPositionOverride = allowOverride;
        }

        private void FixedUpdate()
        {
            if (_preventMovement)
            {
                return;
            }

            if (Input.GetMouseButtonDown(0) && _allowTargetPositionOverride)
            {
                // Left clicked was pressed. Change the target position
                // The input is taken in screen space so convert in world space
                _currentTargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if (_currentTargetPosition == null)
            {
                // No need to move
                return;
            }

            // We have a destination so we are moving
            isMoving = true;
            MoveTo((Vector2)_currentTargetPosition);
        }
    }
}

