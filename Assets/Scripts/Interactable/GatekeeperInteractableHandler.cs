using Dialog;
using Movement;
using UnityEngine;

namespace Interactable
{
    public class GatekeeperInteractableHandler : AbstractInteractableHandler
    {
        public DialogManager dialogManager;
        private bool _doorOpened = false;

        private void OpenKeypad()
        {
            Keypad k = GetComponent<Keypad>();
            k.OpenKeypad(this);
        }

        public void OpenDoor()
        {
            _doorOpened = true;
        }
    
        private void OnDialogLineEnded()
        {
            
            // Show the next dialog line
            if (dialogManager.currentDialogLineIndex == 6 || dialogManager.currentDialogLineIndex == 7)
            {
                // Show the last dialog line
                OpenKeypad();
            }
            else
            {
                if (dialogManager.currentDialogLineIndex == 8)
                {
                    base.StopInteraction();
                }
                else
                {
                    // Show the next dialog line
                    dialogManager.ShowDialog(OnDialogLineEnded);
                }
                
            }
        }

        public void ContinueDialog(int dialogIndex)
        {
            dialogManager.ShowDialog(dialogIndex,OnDialogLineEnded);
        }

        protected override void OnInteract()
        {
            if( _doorOpened == false)
            {
                dialogManager.ShowDialog(0, OnDialogLineEnded);
            }
            else
            {
                dialogManager.ShowDialog(8,base.StopInteraction);
            }
        }
    }
}