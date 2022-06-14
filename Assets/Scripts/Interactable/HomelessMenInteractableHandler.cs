using System.Collections;
using System.Collections.Generic;
using Dialog;
using Interactable;
using Inventory;
using Scenes;
using UnityEngine;


public class HomelessMenInteractableHandler : AbstractInteractableHandler
{
    public DialogManager dialogManager;
    public LetterInventoryController letterInventoryController;
    [SerializeField] private Teleporter _teleporter;

    protected override void StopInteraction()
    {
        base.StopInteraction();

        // Give the letter
        // letterInventoryController.GiveLetter(2);
        // Then unlock the next level
        
        _teleporter.gameObject.SetActive(true);
    }
    
    private void OnDialogLineEnded()
    {
        if (dialogManager.currentDialogLineIndex == 10)
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
