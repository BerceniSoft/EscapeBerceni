using Enums;
using UnityEngine;

namespace Movement
{
    public class MainCharacterMovement : Followable
    {
        public bool IsMoving { get; private set; } = false;

        [SerializeField]
        private float movementSpeed = 3.0f;

        [SerializeField]
        private new Camera camera;

        private Vector2? _currentTargetPosition;
        private Animator _anim;

        // If false, mouse movement won't be able to change the target position
        private bool _allowTargetPositionOverride = true;
        private bool _preventMovement;

        private void Awake()
        {
            if (camera == null)
            {
                camera = Camera.main;
            }
        }

        protected override void Start()
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

            if (Input.GetMouseButtonDown(0) && _allowTargetPositionOverride)
            {
                // Left clicked was pressed. Change the target position
                // The input is taken in screen space so convert in world space
                _currentTargetPosition = camera.ScreenToWorldPoint(Input.mousePosition);
            }

            if (_currentTargetPosition == null)
            {
                // No need to move
                return;
            }

            // We have a destination so we are moving
            MoveTo((Vector2) _currentTargetPosition);
        }

        private void SetWalkingAnimation(bool isWalking)
        {
            _anim.SetBool("IsWalking", isWalking);
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
            if (IsMoving == false)
            {
                SetWalkingAnimation(true);
                IsMoving = true;
            }

            Vector2 currentPos = transform.position;
            var distance = destination - currentPos;
            // Get the movement velocity vector based on the distance
            // The velocity will gradually decrease this way
            var movement = distance;

            // Get the direction to see if we need to flip the asset
            var dir = currentSpriteOrientation;
            if (currentPos.x < destination.x)
            {
                dir = SpriteOrientation.Right;
            }
            else if (currentPos.x > destination.x)
            {
                dir = SpriteOrientation.Left;
            }

            if (dir != currentSpriteOrientation)
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
                IsMoving = false;
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
    }
}
