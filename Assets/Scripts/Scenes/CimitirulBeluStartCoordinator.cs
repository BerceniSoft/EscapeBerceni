using System;
using System.Collections;
using System.Threading.Tasks;
using Constants;
using Dialog;
using Movement;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scenes
{
    public class CimitirulBeluStartCoordinator : MonoBehaviour
    {
        private const string IsFirstLoadKey = "IS_FIRST_LOAD";
        private const string HasPlayerEnteredKey = "HAS_PLAYER_ENTERED";

        [SerializeField] private DialogManager dialogManager;

        [SerializeField] private MainCharacterMovement mainCharacterMovement;

        private static readonly int ThugLifeAnimParamId = Animator.StringToHash("ThugLife");
        private static readonly float ThugLifeAnimationDurationAndDelay = 1.6f;
        private SceneStorage _sceneStorage;
        public Animator eminescuAnimator;

        private IEnumerator OnDialogLineEnded()
        {
            //  We'll show all 8 dialog lines one after the other
            if (dialogManager.currentDialogLineIndex < 8)
            {
                dialogManager.ShowDialog(() => StartCoroutine(OnDialogLineEnded()));
            }
            else
            {
                // Done with the intro
                _sceneStorage.SetKey(ScenesIds.CimitirulBeluStart, IsFirstLoadKey, "false");
            }

            if (this.dialogManager.currentDialogLineIndex == 8)
            {
                // Show the ThugLife animation
                eminescuAnimator.SetBool(ThugLifeAnimParamId, true);
                // After the transition is done, revert to the floating animation
                yield return new WaitForSeconds(ThugLifeAnimationDurationAndDelay);
                eminescuAnimator.SetBool(ThugLifeAnimParamId, false);
            }
        }

        void ShowDialog()
        {
            this.dialogManager.ShowDialog(() => StartCoroutine(OnDialogLineEnded()));
        }

        private void Start()
        {
            _sceneStorage = SceneStorage.GetInstance();
        }

        private void Update()
        {
            var isFirstLoad = _sceneStorage.GetKey(ScenesIds.CimitirulBeluStart, IsFirstLoadKey) == null;
            if (isFirstLoad)
            {
                var hasPlayerEntered = _sceneStorage.GetKey(ScenesIds.CimitirulBeluStart, HasPlayerEnteredKey) != null;
                if (!hasPlayerEntered)
                {
                    // Move the character in scene
                    mainCharacterMovement.WalkTo(new Vector2(-6, -2), false);
                    _sceneStorage.SetKey(ScenesIds.CimitirulBeluStart, HasPlayerEnteredKey, "true");
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