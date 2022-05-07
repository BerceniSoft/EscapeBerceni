using System.Collections;
using System.Collections.Generic;
using Constants;
using Dialog;
using Movement;
using Scenes;
using UnityEngine;

namespace Scenes
{
    public class CimitirulBeluTombsCoordinator : MonoBehaviour
    {
        private const string IsFirstLoadKey = "IS_FIRST_LOAD";
        private const string HasPlayerEnteredKey = "HAS_PLAYER_ENTERED";

        [SerializeField] private DialogManager dialogManager;

        [SerializeField] private MainCharacterMovement mainCharacterMovement;
        private SceneStorage _sceneStorage;


        private void ShowInitialDialog()
        {
            dialogManager.ShowDialog(OnInitialDialogDone);
        }

        private void OnInitialDialogDone()
        {
            _sceneStorage.SetKey(ScenesIds.CimitirulBeluTombs, IsFirstLoadKey, "false");
        }

        // Start is called before the first frame update
        void Start()
        {
            _sceneStorage = SceneStorage.GetInstance();
        }

        // Update is called once per frame
        void Update()
        {
            var isFirstLoad = _sceneStorage.GetKey(ScenesIds.CimitirulBeluTombs, IsFirstLoadKey) == null;
            if (isFirstLoad)
            {
                var hasPlayerEntered = _sceneStorage.GetKey(ScenesIds.CimitirulBeluStart, HasPlayerEnteredKey) != null;
                if (!hasPlayerEntered)
                {
                    // Move the character in scene
                    mainCharacterMovement.SetDestination(new Vector2(-3.5f, -2), false);
                    _sceneStorage.SetKey(ScenesIds.CimitirulBeluStart, HasPlayerEnteredKey, "true");
                }

                // After the movement is done, show the dialog
                if (!dialogManager.IsDialogBeingShown && !mainCharacterMovement.isMoving)
                {
                    // ShowInitialDialog();
                }
            }
        }
    }
}
