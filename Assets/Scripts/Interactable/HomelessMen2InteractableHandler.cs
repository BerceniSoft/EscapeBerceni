using System.Collections;
using System.Collections.Generic;
using Dialog;
using Interactable;
using Inventory;
using UnityEngine;


public class HomelessMen2InteractableHandler : AbstractInteractableHandler
{
    public DialogManager dialogManager;
    public LetterInventoryController letterInventoryController;

    protected override void StopInteraction()
    {
        base.StopInteraction();

        // Give the letter
        // letterInventoryController.GiveLetter(2);
        // Then unlock the next level
    }
    
    private void OnDialogLineEnded()
    {
        if (dialogManager.currentDialogLineIndex == 4)
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
        dialogManager.ShowDialog(0, OnDialogLineEnded);
    }
}