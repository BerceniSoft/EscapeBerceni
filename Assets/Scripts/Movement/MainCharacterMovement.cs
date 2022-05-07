using Constants;
using Dialog;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Movement
{
    public class MainCharacterMovement : MonoBehaviour
    {
        public DialogManager dialogManager;
        public bool isMoving = false;
        public SpriteOrientation initialSpriteOrientation;
        public SpriteOrientation currentSpriteOrientation;

        [SerializeField] private float movementSpeed = 3.0f;

        private Rigidbody2D _rigidBody2D;
        private Vector2? _currentTargetPosition;

        private Animator _anim;

        // The GameObject that holds all the sprite renderer components
        private Transform _spriteContainer;

        // If false, mouse movement won't be able to change the target position
        private bool _allowTargetPositionOverride = true;
        private bool _preventMovement;

        private void SetWalkingAnimation(bool isWalking)
        {
            _anim.SetBool("IsWalking", isWalking);
        }

        private void SetSpriteOrientation(SpriteOrientation spriteOrientation)
        {
            currentSpriteOrientation = spriteOrientation;
            
            var shouldBeFlipped = spriteOrientation != initialSpriteOrientation;
            if (_spriteContainer != null)
            {
                // Scale on the x axis in the appropriate direction
                _spriteContainer.localScale = new Vector3(shouldBeFlipped ? -1 : 1, 1, 1);
            }
        }

        private void Start()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
            foreach (Transform child in transform)
            {
                if (child.CompareTag(Tags.SpriteContainerTag))
                {
                    _spriteContainer = child;
                }
            }
        }

        public void PauseMovement()
        {
            _preventMovement = true;
            // Delete the current velocity
            // When resumed, the next call to update will set back the velocity
            _rigidBody2D.velocity = new Vector2(0, 0);
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
            var dir = currentPos.x < destination.x ? SpriteOrientation.Right : SpriteOrientation.Left;
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
                isMoving = false;
                SetWalkingAnimation(false);
                _currentTargetPosition = null;

                // Allow mouse movement if it was disabled before
                _allowTargetPositionOverride = true;
            }

            movement.Normalize();
            _rigidBody2D.velocity = movement * movementSpeed;
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