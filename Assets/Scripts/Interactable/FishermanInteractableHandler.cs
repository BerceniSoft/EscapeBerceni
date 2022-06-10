using System.Collections;
using System.Collections.Generic;
using Dialog;
using Interactable;
using Inventory;
using UnityEngine;

public class FishermanInteractableHandler : AbstractInteractableHandler
{
    public DialogManager dialogManager;
    
    public DuckInventoryController duckInventoryController;
    
    protected override void StopInteraction()
    {
        base.StopInteraction();

        // Give the duck
        duckInventoryController.GiveDuck();
        // Then unlock the next scene
    }
    
    private void OnDialogLineEnded()
    {
        // Show the next dialog line
        if (dialogManager.currentDialogLineIndex == 16)
        {
            // Show the last dialog line
            dialogManager.ShowDialog(StopInteraction);
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
    