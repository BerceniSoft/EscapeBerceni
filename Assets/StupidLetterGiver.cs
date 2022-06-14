using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;

public class StupidLetterGiver : Interactable.AbstractInteractableHandler
{
    [SerializeField]
    private LetterInventoryController letterInventoryController;
    
    protected override void OnInteract()
    {
        letterInventoryController.GiveLetter(0);    
    }
}
