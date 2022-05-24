using Movement;
using UnityEngine;

namespace Scenes.Level2
{
    public class CimitirulBeluFinalCoordinator : MonoBehaviour
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