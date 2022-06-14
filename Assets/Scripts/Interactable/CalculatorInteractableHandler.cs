using System.Collections;
using System.Collections.Generic;
using Dialog;
using Interactable;
using Inventory;
using Scenes;
using UnityEngine;

public class CalculatorInteractableHandler : AbstractInteractableHandler
{
    public DialogManager dialogManager;
    [SerializeField]
    private Teleporter _teleporter;
    protected override void StopInteraction()
    {
        base.StopInteraction();
        _teleporter.gameObject.SetActive(true);
    }
    
    private void OnDialogLineEnded()
    {
        // Show the next dialog line
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

    protected override void OnInteract()
    {
        if (enabled)
            dialogManager.ShowDialog(3, OnDialogLineEnded);
    }
}