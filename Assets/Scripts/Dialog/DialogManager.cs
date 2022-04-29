using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#nullable enable

public class DialogManager : MonoBehaviour
{
    private bool _isDialogBeingShown;
    public int currentDialogLineIndex;
    public DialogBox dialogBox;
    public AbstractDialogTree dialogTree;
    public bool IsDialogBeingShown{
        get
        {
            return this._isDialogBeingShown;
        }
    }
    public MainCharacterMovement mainCharacterMovement;

    private void OnBeginDialog()
    {
        this.mainCharacterMovement.PauseMovement();
        this._isDialogBeingShown = true;
    }

    private void OnEndDialog(Action? onDone)
    {
        this.mainCharacterMovement.ResumeMovement();
        Debug.Log("Hey");
        this._isDialogBeingShown = false;
        if(onDone != null)
        {
            onDone();
        }
      
    }

    // Start is called before the first frame update
    void Start()
    {
        this.currentDialogLineIndex = 0;
    }

    public void ShowDialog()
    {
        this.OnBeginDialog();
        DialogLineInfo dialogLineInfo = this.dialogTree.GetDialogLine(this.currentDialogLineIndex);
        StartCoroutine(
            this.dialogBox.ShowDialog(
                dialogLineInfo.DialogLine,
                dialogLineInfo.SpeakerName,
                dialogLineInfo.Answers,
                ()=>this.OnEndDialog(null)
            )
        );

        // Increment the dialog line index so we get the next line next time around
        this.currentDialogLineIndex++;
    }

    // Skip to a particular line
    public void ShowDialog(int lineIndex)
    {
        this.currentDialogLineIndex = lineIndex;
        this.ShowDialog();
    }

    public void ShowDialog(Action onDone)
    {
        this.OnBeginDialog();
        DialogLineInfo dialogLineInfo = this.dialogTree.GetDialogLine(this.currentDialogLineIndex);
        StartCoroutine(
            this.dialogBox.ShowDialog(
                dialogLineInfo.DialogLine,
                dialogLineInfo.SpeakerName,
                dialogLineInfo.Answers,
                ()=>this.OnEndDialog(onDone)
            )
        );

        // Increment the dialog line index so we get the next line next time around
        this.currentDialogLineIndex++;
    }

    public void ShowDialog(int lineIndex, Action onDone)
    {
        this.currentDialogLineIndex = lineIndex;
        this.ShowDialog(onDone);
    }

    public void OnDialogOptionPicked(int optionIndex)
    {
        this.currentDialogLineIndex = this.dialogTree.OnDialogOptionPicked(
            optionIndex,
            this.currentDialogLineIndex
        );
    }

    public void HideDialogBox()
    {
        this.dialogBox.HideDialogBox();
    }
}
