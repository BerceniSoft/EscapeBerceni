using System;
using System.Collections;
using Dialog;
using Movement;
using UnityEngine;

public class SubwayTrainCoordinator : MonoBehaviour
{
    [SerializeField]
    private MainCharacterMovement mainCharacterMovement;

    [SerializeField]
    private DialogManager dialogManager;

    [SerializeField]
    private Transform startPoint;

    private bool _showedDialog = false;
    
    private void Start()
    {
        mainCharacterMovement.WalkTo(startPoint.position);
    }

    private void Update()
    {
        if (!_showedDialog && !mainCharacterMovement.isMoving)
        {
            _showedDialog = true;
            mainCharacterMovement.PauseMovement();
            mainCharacterMovement.AllowTargetPositionOverride = false;
            dialogManager.ShowDialog(ShowNextDialogLine);
        }
    }

    private void ShowNextDialogLine()
    {
        if (!dialogManager.HasFinished())
        {
            dialogManager.ShowDialog(ShowNextDialogLine);
        }
        else
        {
            mainCharacterMovement.ResumeMovement();
            mainCharacterMovement.AllowTargetPositionOverride = true;
        }
    }
}
