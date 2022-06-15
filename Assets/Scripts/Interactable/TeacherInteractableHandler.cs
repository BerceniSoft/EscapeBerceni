using Dialog;
using Movement;
using Scenes;
using UnityEngine;

namespace Interactable
{
    public class TeacherInteractableHandler : AbstractInteractableHandler
    {
        public DialogManager dialogManager;
        private bool _firstMeetDone = false;
        public Teleporter _teleporter;

      
    
        private void OnDialogLineEnded()
        {
            
            // Show the next dialog line
            if (dialogManager.currentDialogLineIndex == 5)
            {
                // Stop dialog
                base.StopInteraction();
                _firstMeetDone = true;
                _teleporter.ToggleActvie();

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
            if(_firstMeetDone == false)
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