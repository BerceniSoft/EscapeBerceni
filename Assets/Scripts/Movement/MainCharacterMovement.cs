using System;
using Constants;
using Dialog;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Movement
{
    public class MainCharacterMovement : Followable

    {
        // If false, mouse movement won't be able to change the target position
        private bool _allowTargetPositionOverride = true;
        private Camera _mainCamera;

        protected override void Start()
        {
            base.Start();
            _mainCamera = Camera.main;
        }

        public bool CanMoveOnClick()
        {
            // If the character doesn't have its movement paused and target position override is allowed,
            // then clicking on a point will result in movement
            return !IsMovementPrevented() && _allowTargetPositionOverride;
        }

        public void WalkTo(Vector2 destination, bool allowOverride)
        {
            _allowTargetPositionOverride = allowOverride;
            var hasReachedDestination = WalkTo(destination);
            // If we reached the destination set allow mouse destination override
            _allowTargetPositionOverride = _allowTargetPositionOverride || hasReachedDestination;
        }

        private void FixedUpdate()
        {
            if (IsMovementPrevented())
            {
                return;
            }

            // Left clicked was pressed. Change the target position
            // The input is taken in screen space so convert in world space
            Vector2? newTargetPosition = Input.GetMouseButtonDown(0) && _allowTargetPositionOverride
                ? _mainCamera.ScreenToWorldPoint(Input.mousePosition)
                : null;

            if (newTargetPosition != null)
            {
                // We have a new destination
                SetDestination((Vector2) newTargetPosition);
            }
            // Move to the current destination
            var hasReachedDest = MoveToDestination();
            // If we reached the destination set allow mouse destination override
            _allowTargetPositionOverride = _allowTargetPositionOverride || hasReachedDest;
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