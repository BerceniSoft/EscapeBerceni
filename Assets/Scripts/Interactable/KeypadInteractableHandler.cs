using Dialog;
using Movement;
using UnityEngine;

namespace Interactable
{
    public class KeypadInteractableHandler : AbstractInteractableHandler
    {
        public DialogManager dialogManager;

        private void OpenKeypad()
        {
            Keypad k = GetComponent<Keypad>();
            k.OpenKeypad();
        }
    
        private void OnDialogLineEnded()
        {
            // Show the next dialog line
            if (dialogManager.currentDialogLineIndex == 2)
            {
                // Show the last dialog line
                dialogManager.ShowDialog(OpenKeypad);
            }
            else
            {
                // Show the next dialog line
                dialogManager.ShowDialog(OnDialogLineEnded);
            }
        }

        protected override void OnInteract()
        {
            dialogManager.ShowDialog(1, OnDialogLineEnded);
        }
    }
}