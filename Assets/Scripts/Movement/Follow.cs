using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Movement
{
    public class Follow : Walks
    {

        public Followable target;
        
        // Update is called once per frame
        void Update()
        {
            SetVelocity(target.GetVelocity());
            var targetSpriteOrientation = target.GetSpriteOrientation();

            if (targetSpriteOrientation != _currentSpriteOrientation)
            {
                SetSpriteOrientation(targetSpriteOrientation);
            }
        }
    }
}
