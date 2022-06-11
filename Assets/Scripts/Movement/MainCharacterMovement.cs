using System;
using Constants;
using UnityEngine;

namespace Movement
{
    public class MainCharacterMovement : Followable
    {
        // If false, mouse movement won't be able to change the target position
        public bool AllowTargetPositionOverride { get; set; } = true;
        private Camera _mainCamera;

        protected override void Awake()
        {
            base.Awake();
            _mainCamera = Camera.main;
        }


        public bool CanMoveOnClick()
        {
            // If the character doesn't have its movement paused and target position override is allowed,
            // then clicking on a point will result in movement
            return !IsMovementPrevented() && AllowTargetPositionOverride;
        }

        public void WalkTo(Vector2 destination, bool allowOverride)
        {
            AllowTargetPositionOverride = allowOverride;
            var hasReachedDestination = WalkTo(destination);
            // If we reached the destination set allow mouse destination override
            AllowTargetPositionOverride = AllowTargetPositionOverride || hasReachedDestination;
        }

        private void Update()
        {
            // Left clicked was pressed. Change the target position
            // The input is taken in screen space so convert in world space
            Vector2? newTargetPosition = Input.GetMouseButtonDown(0) && AllowTargetPositionOverride
                ? _mainCamera.ScreenToWorldPoint(Input.mousePosition)
                : null;

            if (newTargetPosition != null)
            {
                // We have a new destination
                SetDestination((Vector2) newTargetPosition);
            }
        }

        private void FixedUpdate()
        {
            if (IsMovementPrevented())
            {
                return;
            }

            // Move to the current destination
            var hasReachedDest = MoveToDestination();
            // If we reached the destination set allow mouse destination override
            AllowTargetPositionOverride = AllowTargetPositionOverride || hasReachedDest;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(Layers.ObstacleLayer))
            {
                // Hit an obstacle
                // Stop the movement
                StopMovement();
            }
        }
    }
}