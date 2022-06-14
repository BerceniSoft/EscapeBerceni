using System.Collections;
using System.Collections.Generic;
using Dialog;
using Interactable;
using Inventory;
using Scenes;
using UnityEngine;

public class Mom1InteractableHandler : AbstractInteractableHandler
{
    public DialogManager dialogManager;
    public LetterInventoryController letterInventoryController;
    [SerializeField]
    private Teleporter _teleporter;
    protected override void StopInteraction()
    {
        base.StopInteraction();

        // Give the letter
        letterInventoryController.GiveLetter(3);
        _teleporter.gameObject.SetActive(true);
        // Then unlock the next level
    }
    
    private void OnDialogLineEnded()
    {
        // Show the next dialog line
        if (dialogManager.currentDialogLineIndex == 6)
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
        dialogManager.ShowDialog(4, OnDialogLineEnded);
    }
}