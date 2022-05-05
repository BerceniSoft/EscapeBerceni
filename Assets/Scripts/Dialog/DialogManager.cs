#nullable enable

using System;
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

        private void OnEndDialog(Action? onDone)
        {
            mainCharacterMovement.ResumeMovement();
            IsDialogBeingShown = false;

            onDone?.Invoke();
        }

        private void Start()
        {
            currentDialogLineIndex = 6;
        }

        public void ShowDialog()
        {
            OnBeginDialog();
            var dialogLineInfo = dialogTree.GetDialogLine(currentDialogLineIndex);
            StartCoroutine(
                dialogBox.ShowDialog(
                    dialogLineInfo.DialogLine,
                    dialogLineInfo.SpeakerName,
                    dialogLineInfo.Answers,
                    () => OnEndDialog(null)
                )
            );

            // Increment the dialog line index so we get the next line next time around
            currentDialogLineIndex++;
        }

        // Skip to a particular line
        public void ShowDialog(int lineIndex)
        {
            currentDialogLineIndex = lineIndex;
            ShowDialog();
        }

        public void ShowDialog(Action onDone)
        {
            OnBeginDialog();
            var dialogLineInfo = dialogTree.GetDialogLine(currentDialogLineIndex);
            StartCoroutine(
                dialogBox.ShowDialog(
                    dialogLineInfo.DialogLine,
                    dialogLineInfo.SpeakerName,
                    dialogLineInfo.Answers,
                    () => OnEndDialog(onDone)
                )
            );

            // Increment the dialog line index so we get the next line next time around
            currentDialogLineIndex++;
        }

        public void ShowDialog(int lineIndex, Action onDone)
        {
            currentDialogLineIndex = lineIndex;
            ShowDialog(onDone);
        }

        public void OnDialogOptionPicked(int optionIndex)
        {
            currentDialogLineIndex = dialogTree.OnDialogOptionPicked(
                optionIndex,
                currentDialogLineIndex
            );
        }

        public void HideDialogBox()
        {
            dialogBox.HideDialogBox();
        }
    }
}