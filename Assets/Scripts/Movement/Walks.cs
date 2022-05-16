using System;
using Constants;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Movement
{
    public class Walks : MonoBehaviour
    {
        protected SpriteOrientation _currentSpriteOrientation;

        // The GameObject that holds all the sprite renderer components
        private Transform _spriteContainer;
        private Rigidbody2D _rigidBody2D;
        private Vector2? _currentTargetPosition;
        private Animator _anim;
        [SerializeField] private float movementSpeed = 3.0f;
        private bool _preventMovement;


        public bool isMoving = false;
       public String walkingAnimParamName = "IsWalking";


        public SpriteOrientation initialSpriteOrientation;

        protected void SetSpriteOrientation(SpriteOrientation spriteOrientation)
        {
            _currentSpriteOrientation = spriteOrientation;

            var shouldBeFlipped = spriteOrientation != initialSpriteOrientation;
            if (_spriteContainer != null)
            {
                // Scale on the x axis in the appropriate direction
                _spriteContainer.localScale = new Vector3(shouldBeFlipped ? -1 : 1, 1, 1);
            }
        }

        virtual protected void Start()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _currentSpriteOrientation = initialSpriteOrientation;
            foreach (Transform child in transform)
            {
                if (child.CompareTag(Tags.SpriteContainerTag))
                {
                    _spriteContainer = child;
                }
            }

            _anim = GetComponent<Animator>();
        }

        protected void SetVelocity(Vector3 velocity)
        {
            _rigidBody2D.velocity = velocity;
        }

        public Vector3 GetVelocity()
        {
            return _rigidBody2D.velocity;
        }

        protected Vector2 GetPosition()
        {
            return _rigidBody2D.position;
        }

        protected bool IsMovementPrevented()
        {
            return this._preventMovement;
        }

        private void SetWalkingAnimation(bool isWalking)
        {
            _anim.SetBool(walkingAnimParamName, isWalking);
        }

        /**
         * Return whether or not the object is at the destination
         */
        protected bool MoveToDestination()
        {
            if (_currentTargetPosition == null)
            {
                // No destination to be reached
                return false; 
            }

            Vector2 destination = (Vector2) _currentTargetPosition;
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
                
                SetVelocity(movement * movementSpeed);

                return true;
            }

            movement.Normalize();
            SetVelocity(movement * movementSpeed);
            return false;
        }


        /**
        * Returns true if the object reached its destination
        */
        protected void SetDestination(Vector2 destination)
        {
            _currentTargetPosition = destination;
        }

        public bool WalkTo(Vector2 destination)
        {
            _currentTargetPosition = destination;
            return MoveToDestination();
        }


        public void PauseMovement()
        {
            _preventMovement = true;
            // Delete the current velocity
            // When resumed, the next call to update will set back the velocity
            SetVelocity(new Vector2(0, 0));
            SetWalkingAnimation(false);
        }

        public void StopMovement()
        {
            SetVelocity(new Vector2(0, 0));
            SetWalkingAnimation(false);
            _currentTargetPosition = transform.position;
            isMoving = false;
        }

        public void ResumeMovement()
        {
            _preventMovement = false;
            if (_currentTargetPosition != null)
            {
                SetWalkingAnimation(true);
            }
        }
    }
}