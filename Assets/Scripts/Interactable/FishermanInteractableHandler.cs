using System.Collections;
using System.Collections.Generic;
using Dialog;
using Interactable;
using Inventory;
using UnityEngine;

public class FishermanInteractableHandler : AbstractInteractableHandler
{
    public DialogManager dialogManager;
    public GameObject gameObject;
    public Sprite duckHead;
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
        if (dialogManager.currentDialogLineIndex == 15)
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = duckHead;
            spriteRenderer.transform.position = new Vector3(spriteRenderer.transform.position.x -0.2f, spriteRenderer.transform.position.y);
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
    