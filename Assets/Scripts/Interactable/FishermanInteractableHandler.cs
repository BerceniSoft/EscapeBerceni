using System.Collections;
using System.Collections.Generic;
using Dialog;
using Interactable;
using Inventory;
using Scenes;
using UnityEngine;

public class FishermanInteractableHandler : AbstractInteractableHandler
{
    public DialogManager dialogManager;
    public GameObject gameObject;
    public GameObject body;
    public Sprite duckHead;
    public DuckInventoryController duckInventoryController;
    [SerializeField] private Teleporter _teleporter;

    protected override void StopInteraction()
    {
        base.StopInteraction();

        // Give the duck
        duckInventoryController.GiveDuck();
        // Then unlock the next scene
        
        _teleporter.gameObject.SetActive(true);
    }
    
    private void OnDialogLineEnded()
    {
        // Show the next dialog line
        if (dialogManager.currentDialogLineIndex == 15)
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = duckHead;
            SpriteRenderer bodyRenderer = gameObject.GetComponent<SpriteRenderer>();
            
            spriteRenderer.transform.position = new Vector3(bodyRenderer.transform.position.x - 0.2f, bodyRenderer.transform.position.y + 1.1f);
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
    