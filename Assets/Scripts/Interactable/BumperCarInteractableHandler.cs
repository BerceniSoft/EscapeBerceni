using System.Collections;
using System.Collections.Generic;
using Dialog;
using Interactable;
using Inventory;
using UnityEngine;

public class BumperCarInteractableHandler : AbstractInteractableHandler
{
    public DialogManager dialogManager;
    protected override void StopInteraction()
    {
        base.StopInteraction();
    }
    
    /*private void OnDialogLineEnded()
    {
        StopInteraction();
    }*/

    protected override void OnInteract()
    {
        if (enabled)
            dialogManager.ShowDialog(12, StopInteraction);
    }
}