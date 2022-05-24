using System.Collections;
using System.Collections.Generic;
using Dialog;
using Interactable;
using UnityEngine;

public class PriestInteractableHandler : AbstractInteractableHandler
{
    private static readonly int ExorcisedAnimParamId = Animator.StringToHash("Exorcised");

    public DialogManager dialogManager;
    public Animator eminescuAnimator;

    protected override void StopInteraction()
    {
        base.StopInteraction();

        // Give the letter
        // Then unlock the next level
    }

    private void OnDialogLineEnded()
    {
        if (dialogManager.currentDialogLineIndex == 9)
        {
            // Play the exorcised animation
            eminescuAnimator.SetBool(ExorcisedAnimParamId, true);
        }

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
        dialogManager.ShowDialog(1, OnDialogLineEnded);
    }
}