using Dialog;
using UnityEngine;

namespace Interactable
{
    public class TombstoneInteractableHandler : AbstractInteractableHandler
    {
        public int dialogLine;
        public DialogManager dialogManager;

        protected override void OnInteract()
        {
            dialogManager.ShowDialog(dialogLine,StopInteraction);
        }
    }
}