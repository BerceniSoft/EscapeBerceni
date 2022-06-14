using Dialog;
using Movement;
using UnityEngine;

namespace Interactable
{
    public class TeacherInteractableHandler : AbstractInteractableHandler
    {
        public DialogManager dialogManager;

      
    
        private void OnDialogLineEnded()
        {
            
            // Show the next dialog line
            if (dialogManager.currentDialogLineIndex == 8)
            {
                // Show the last dialog line
                base.StopInteraction();
            }
            else
            { 
                // Show the next dialog line
                dialogManager.ShowDialog(OnDialogLineEnded);
            }
        }

        public void ContinueDialog(int dialogIndex)
        {
            dialogManager.ShowDialog(dialogIndex,OnDialogLineEnded);
        }

        protected override void OnInteract()
        { 
            dialogManager.ShowDialog(0, OnDialogLineEnded);
        }
    }
}