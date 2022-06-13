using System.Collections;
using System.Collections.Generic;
using Dialog;
using Interactable;
using Inventory;
using UnityEngine;


public class HomelessMen2InteractableHandler : AbstractInteractableHandler
{
    public DialogManager dialogManager;
    public GameObject gameObjectPlayer;
    public GameObject gameObjectBBQ;
    public Sprite head;
    public Sprite bbq;
    public Sprite duckWing;
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
        if (dialogManager.currentDialogLineIndex == 2)
        {
            SpriteRenderer spriteRendererPlayer = gameObjectPlayer.GetComponent<SpriteRenderer>();
            spriteRendererPlayer.sprite = head;
            spriteRendererPlayer.transform.position = new Vector3(spriteRendererPlayer.transform.position.x + 0.2f, spriteRendererPlayer.transform.position.y - 1);

            SpriteRenderer spriteRendererBBQ = gameObjectBBQ.GetComponent<SpriteRenderer>();
            spriteRendererBBQ.sprite = bbq;
            spriteRendererBBQ.transform.position = new Vector3(spriteRendererBBQ.transform.position.x -0.2f, spriteRendererBBQ.transform.position.y);
            
            dialogManager.ShowDialog(OnDialogLineEnded);
        }
        else if (dialogManager.currentDialogLineIndex == 3)
        {
            SpriteRenderer spriteRendererBBQ = gameObjectBBQ.GetComponent<SpriteRenderer>();
            spriteRendererBBQ.sprite = duckWing;
            spriteRendererBBQ.transform.position = new Vector3(spriteRendererBBQ.transform.position.x -0.2f, spriteRendererBBQ.transform.position.y);
            
            dialogManager.ShowDialog(OnDialogLineEnded);
        }
        else if (dialogManager.currentDialogLineIndex == 4)
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