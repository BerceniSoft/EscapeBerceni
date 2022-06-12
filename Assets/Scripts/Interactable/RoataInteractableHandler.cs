using System.Collections;
using System.Collections.Generic;
using Dialog;
using Interactable;
using Inventory;
using UnityEngine;

public class RoataInteractableHandler : AbstractInteractableHandler
{
    public DialogManager dialogManager;
    public CalculatorInteractableHandler calculator;
    
    protected override void StopInteraction()
    {
        base.StopInteraction();
    }
    
    private void OnDialogLineEnded()
    {
        // Show the next dialog line
        if (dialogManager.currentDialogLineIndex == 2)
        {
            // Show the last dialog line
            calculator.enabled = true;
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