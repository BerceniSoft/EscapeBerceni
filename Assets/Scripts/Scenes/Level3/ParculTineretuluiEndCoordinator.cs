using System.Collections;
using Constants;
using Dialog;
using Movement;
using UnityEngine;

namespace Scenes.Level3
{
    public class ParculTineretuluiEndCoordinator
    {
        private bool _hasStartedMovement = false;
        [SerializeField] private MainCharacterMovement mainCharacterMovement;

        private void Update()
        {
            if (!_hasStartedMovement)
            {
                // Move the character in scene
                mainCharacterMovement.WalkTo(new Vector2(-6, -2), false);
                _hasStartedMovement = true;
            }
        }
    }
}