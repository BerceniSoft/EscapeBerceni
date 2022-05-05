using Constants;
using Dialog;
using Movement;
using UnityEngine;

namespace Scenes
{
    public class CimitirulBelu1Coordinator : MonoBehaviour
    {
        private const string IsFirstLoadKey = "IS_FIRST_LOAD";
        private const string HasPlayerEnteredKey = "HAS_PLAYER_ENTERED";

        [SerializeField]
        private DialogManager dialogManager;
        
        [SerializeField]
        private MainCharacterMovement mainCharacterMovement;

        private SceneStorage _sceneStorage;
        public Animator EminescuAnimator;

    private void OnDialogLineEnded()
    {
         if(this.dialogManager.currentDialogLineIndex == 8)
         {
             // Show the ThugLife animation
             this.EminescuAnimator.SetBool("ThugLife",true);
         }

        //  We'll show all 8 dialog lines one after the other
        if(dialogManager.currentDialogLineIndex < 8)
        {
            dialogManager.ShowDialog(OnDialogLineEnded);
        }
        else
        {
            // Done with the intro
            _sceneStorage.AddKey(ScenesIds.CimitirulBelu1, IsFirstLoadKey, "false");
        }
    }

    void ShowDialog()
    {
        this.dialogManager.ShowDialog(this.OnDialogLineEnded);
    }

        private void Start()
        {
            _sceneStorage = SceneStorage.GetInstance();
        }   

        private void Update()
        {
            var isFirstLoad = _sceneStorage.GetKey(ScenesIds.CimitirulBelu1, IsFirstLoadKey) == null;
            if (isFirstLoad)
            {
                var hasPlayerEntered = _sceneStorage.GetKey(ScenesIds.CimitirulBelu1, HasPlayerEnteredKey) != null;
                if (!hasPlayerEntered)
                { 
                    // Move the character in scene
                    mainCharacterMovement.SetDestination(new Vector2(-6, -2), false);
                    _sceneStorage.AddKey(ScenesIds.CimitirulBelu1, HasPlayerEnteredKey, "true");
                }

                // After the movement is done, show the dialog
                if (!dialogManager.IsDialogBeingShown && !mainCharacterMovement.isMoving)
                { 
                    ShowDialog();
                }   
            }
        }
    }
}
