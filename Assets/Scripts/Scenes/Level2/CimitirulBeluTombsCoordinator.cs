using Constants;
using Dialog;
using Movement;
using UnityEngine;

namespace Scenes.Level2
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

        private void Start()
        {
            _sceneStorage = SceneStorage.GetInstance();
        }

        // Update is called once per frame
        private void Update()
        {
            var isFirstLoad = _sceneStorage.GetKey(ScenesIds.CimitirulBeluTombs, IsFirstLoadKey) == null;
            if (isFirstLoad)
            {
                var hasPlayerEntered = _sceneStorage.GetKey(ScenesIds.CimitirulBeluStart, HasPlayerEnteredKey) != null;
                if (!hasPlayerEntered)
                {
                    // Move the character in scene
                    mainCharacterMovement.WalkTo(new Vector2(-3.5f, -2), false);
                    _sceneStorage.SetKey(ScenesIds.CimitirulBeluStart, HasPlayerEnteredKey, "true");
                }

                // After the movement is done, show the dialog
                if (!dialogManager.IsDialogBeingShown && !mainCharacterMovement.isMoving)
                {
                    ShowInitialDialog();
                }
            }
        }
    }
}
