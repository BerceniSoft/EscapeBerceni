using Constants;
using Dialog;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Movement
{
    public class MainCharacterMovement : Followable

    {
        public bool isMoving = false;

        [SerializeField] private float movementSpeed = 3.0f;

        private Vector2? _currentTargetPosition;

        private Animator _anim;

        // If false, mouse movement won't be able to change the target position
        private bool _allowTargetPositionOverride = true;
        private bool _preventMovement;

        private void SetWalkingAnimation(bool isWalking)
        {
            _anim.SetBool("IsWalking", isWalking);
        }


        override protected void Start()
        {
            base.Start();
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _allowTargetPositionOverride && !_preventMovement)
            {
                // Left clicked was pressed. Change the target position
                // The input is taken in screen space so convert in world space
                _currentTargetPosition = camera.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        private void FixedUpdate()
        {
            if (_preventMovement)
            {
                return;
            }

            if (_currentTargetPosition == null)
            {
                // No need to move
                return;
            }

            // We have a destination so we are moving
            IsMoving = true;
            MoveTo((Vector2)_currentTargetPosition);
        }

        public void PauseMovement()
        {
            _preventMovement = true;
            // Delete the current velocity
            // When resumed, the next call to update will set back the velocity
            SetVelocity(new Vector2(0, 0));
            SetWalkingAnimation(false);
        }

        public void ResumeMovement()
        {
            _preventMovement = false;
            if (_currentTargetPosition != null)
            {
                SetWalkingAnimation(true);
            }
        }

        private void MoveTo(Vector2 destination)
        {
            if (isMoving == false)
            {
                SetWalkingAnimation(true);
                isMoving = true;
            }


            Vector2 currentPos = transform.position;
            var distance = destination - currentPos;
            // Get the movement velocity vector based on the distance
            // The velocity will gradually decrease this way
            var movement = distance;

            // Get the direction to see if we need to flip the asset
            var dir = _currentSpriteOrientation;
            if (currentPos.x < destination.x)
            {
                dir = SpriteOrientation.Right;
            }
            else if (currentPos.x > destination.x)
            {
                dir = SpriteOrientation.Left;
            }

            if (dir != _currentSpriteOrientation)
            {
                SetSpriteOrientation(dir);
            }

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
                SetWalkingAnimation(false);
                _currentTargetPosition = null;

                // Allow mouse movement if it was disabled before
                _allowTargetPositionOverride = true;
            }

            movement.Normalize();
            SetVelocity(movement * movementSpeed);
        }

        public void SetDestination(Vector2 destination, bool allowOverride)
        {
            _currentTargetPosition = destination;
            _allowTargetPositionOverride = allowOverride;
            MoveTo(destination);
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
            MoveTo((Vector2) _currentTargetPosition);
        }
    }
}
