using System;
using System.Linq;
using DialogTrees;
using Movement;
using UnityEngine;

namespace Dialog
{
    public class DialogManager : MonoBehaviour
    {
        public int currentDialogLineIndex;
        public DialogBox dialogBox;
        public AbstractDialogTree dialogTree;
        public MainCharacterMovement mainCharacterMovement;

        public bool IsDialogBeingShown { get; private set; }

        private void OnBeginDialog()
        {
            mainCharacterMovement.PauseMovement();
            IsDialogBeingShown = true;
        }

        private void OnEndDialog(Action onDone)
        {
            mainCharacterMovement.ResumeMovement();
            IsDialogBeingShown = false;

            onDone?.Invoke();
        }

        private void Start()
        {
            currentDialogLineIndex = 0;
        }

        public void ShowDialog(Action onDone = null)
        {
            OnBeginDialog();
            var dialogLineInfo = dialogTree.GetDialogLine(currentDialogLineIndex);
            StartCoroutine(
                dialogBox.ShowDialog(
                    dialogLineInfo.DialogLine,
                    dialogLineInfo.SpeakerName,
                    dialogLineInfo.Answers?.Select(x => x.Item1).ToList(),
                    () => OnEndDialog(() =>
                    {
                        currentDialogLineIndex++;
                        onDone?.Invoke();
                    })
                )
            );
        }

        public void ShowDialog(int lineIndex, Action onDone = null)
        {
            currentDialogLineIndex = lineIndex;
            ShowDialog(onDone);
        }

        public void OnDialogOptionPicked(int optionIndex)
        {
            currentDialogLineIndex = dialogTree.OnDialogOptionPicked(
                optionIndex,
                currentDialogLineIndex
            ) - 1; // Subtracting 1 is needed because onDone increments after this.
        }

        public void HideDialogBox()
        {
            dialogBox.HideDialogBox();
        }
    }
}
