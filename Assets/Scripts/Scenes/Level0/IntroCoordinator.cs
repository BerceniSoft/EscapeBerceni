using System;
using System.Collections;
using Dialog;
using DialogTrees;
using DialogTrees.Level0;
using Movement;
using UnityEngine;

namespace Scenes.Level0
{
    public class IntroCoordinator : MonoBehaviour
    {
        private enum State
        {
            IntroDialog,
            StartDialog,
            AfterStart
        }

        [SerializeField]
        private DialogManager dialogManager;

        [SerializeField]
        private Transform startPoint;

        [SerializeField]
        private MainCharacterMovement mainCharacterMovement;

        [SerializeField]
        private AbstractDialogTree introDialogTree;

        [SerializeField]
        private AbstractDialogTree afterEntranceDialogTree;

        private State _currentState = State.IntroDialog;

        private void Start()
        {
            dialogManager.dialogTree = introDialogTree;
            ShowIntroDialog();
        }

        private void Update()
        {
            switch (_currentState)
            {
                case State.IntroDialog:
                    break;
                case State.StartDialog:
                    mainCharacterMovement.WalkTo(startPoint.position, false);
                    if (!dialogManager.IsDialogBeingShown && !mainCharacterMovement.isMoving)
                    {
                        ShowAfterEntranceDialog();
                    }
                    break;
                case State.AfterStart:
                    break;
            }
        }

        private void ShowIntroDialog()
        {
            if (dialogManager.currentDialogLineIndex < dialogManager.dialogTree.DialogLineInfos.Length)
            {
                dialogManager.ShowDialog(ShowIntroDialog);
            }
            else
            {
                _currentState = State.StartDialog;
                dialogManager.currentDialogLineIndex = 0;
                dialogManager.dialogTree = afterEntranceDialogTree;
            }
        }

        private void ShowAfterEntranceDialog()
        {
            if (dialogManager.currentDialogLineIndex < dialogManager.dialogTree.DialogLineInfos.Length)
            {
                dialogManager.ShowDialog(ShowAfterEntranceDialog);
            }
            else
            {
                _currentState = State.AfterStart;
            }
        }
    }
}
