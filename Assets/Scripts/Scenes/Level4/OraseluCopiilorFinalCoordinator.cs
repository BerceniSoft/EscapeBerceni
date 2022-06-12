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
        private bool debug = true;
        
        private IEnumerator OnDialogLineEnded()
        {
            Debug.Log(dialogManager.currentDialogLineIndex);
            //  We'll show all 8 dialog lines one after the other
            if (dialogManager.currentDialogLineIndex < 4)
            {
                Debug.Log("true");
                dialogManager.ShowDialog(() => StartCoroutine(OnDialogLineEnded()));
            }
            else
            {
                debug = false;
                Debug.Log(dialogManager.currentDialogLineIndex < 4);
                // Done with the intro
                
                // _sceneStorage.SetKey(ScenesIds.OraselFinal, IsFirstLoadKey, "false");
                
                // After the transition is done, revert to the floating animation
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
            if (!dialogManager.IsDialogBeingShown && !mainCharacterMovement.isMoving && debug)
            {
                ShowDialog();
            }
        }
    }
}