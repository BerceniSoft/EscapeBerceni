using System.Collections;
using System.Collections.Generic;
using Dialog;
using Interactable;
using Inventory;
using UnityEngine;


public class HomelessMenInteractableHandler : AbstractInteractableHandler
{
    public DialogManager dialogManager;
    public LetterInventoryController letterInventoryController;
    public DuckInventoryController duckInvectoryController;
        
    protected override void StopInteraction()
    {
        base.StopInteraction();

        // Give the letter
        letterInventoryController.GiveLetter(2);
        // Then unlock the next level
    }
    
    private void OnDialogLineEnded()
    {
        if (duckInvectoryController.duck.has)
        {
            if (dialogManager.currentDialogLineIndex == 5)
            {
                // Remove duck from inventory
                duckInvectoryController.RemoveDuck();
                // Show the last dialog line
                dialogManager.ShowDialog(StopInteraction);
            }
            else
            {
                // Show the next dialog line
                dialogManager.ShowDialog(OnDialogLineEnded);
            }
        }
        else
        {
            if (dialogManager.currentDialogLineIndex == 11)
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
        
    }
    
    protected override void OnInteract()
    {
        dialogManager.ShowDialog(1, OnDialogLineEnded);
    }
}
