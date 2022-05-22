using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Movement
{
    public class Follow : Walks
    {
        private bool _isWaitingOrientationChange = false;
        public Followable target;
        public float distanceToTarget;

        protected override void Awake()
        {
            base.Awake();
            // Align the orientation of this game object to the target
            var targetSpriteOrientation = target.GetSpriteOrientation();
            SetSpriteOrientation(targetSpriteOrientation);
        }

        private void Update()
        {
            var targetSpriteOrientation = target.GetSpriteOrientation();

            if (_isWaitingOrientationChange)
            {
                // Check if the distance was achieved
                if (target.GetDistanceTo(GetPosition()) >= distanceToTarget)
                {
                    // Change the orientation and start moving again
                    _isWaitingOrientationChange = false;
                    SetSpriteOrientation(targetSpriteOrientation);
                }
            }

            if (targetSpriteOrientation != _currentSpriteOrientation)
            {
                // The orientation of the target changed
                // Wait until the target established `distanceToTarget` in the other direction from the GameObject that follows the target
                // then move the following game object
                _isWaitingOrientationChange = true;
            }

            if (!_isWaitingOrientationChange)
            {
                SetVelocity(target.GetVelocity());
            }
        }
    }
}
