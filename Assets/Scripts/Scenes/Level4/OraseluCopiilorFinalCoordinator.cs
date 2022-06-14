using System.Collections;
using Constants;
using Dialog;
using Movement;
using UnityEngine;

namespace Scenes.Level4
{
    public class OraseluCopiilorFinalCoordinator : MonoBehaviour
    {
        private const string IsFirstLoadKey = "IS_FIRST_LOAD";
        private bool _hasStartedMovement = false;
        [SerializeField] private MainCharacterMovement mainCharacterMovement;

        [SerializeField]
        private DialogManager dialogManager;
        private SceneStorage _sceneStorage;
        private bool _hasDisplayedInitialDialogue = false;
        
        private IEnumerator OnDialogLineEnded()
        {
            //  We'll show first 3 dialog lines one after the other
            if (dialogManager.currentDialogLineIndex < 4)
            {
                dialogManager.ShowDialog(() => StartCoroutine(OnDialogLineEnded()));
            }
            else
            {
                _hasDisplayedInitialDialogue  = true;
                // Done with the intro
                yield return new WaitForSeconds(1.6f);
            }
        }
        private void ShowDialog()
        {
            Debug.Log("55");
            dialogManager.ShowDialog(() => StartCoroutine(OnDialogLineEnded()));
        }
        private void Update()
        {
            if (!_hasStartedMovement)
            {
                // Move the character in scene
                mainCharacterMovement.WalkTo(new Vector2(-6, -1), false);
                _hasStartedMovement = true;
            }
            if (!dialogManager.IsDialogBeingShown && !mainCharacterMovement.isMoving && !_hasDisplayedInitialDialogue )
            {
                ShowDialog();
            }
        }
    }
}