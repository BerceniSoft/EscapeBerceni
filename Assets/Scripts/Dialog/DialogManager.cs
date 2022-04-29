using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogManager : MonoBehaviour
{
    public int currentDialogLineIndex;
    public DialogBox dialogBox;
    public AbstractDialogTree dialogTree;

    // Start is called before the first frame update
    void Start()
    {
        this.currentDialogLineIndex = 0;
    }

    public void ShowDialog()
    {
        DialogLineInfo dialogLineInfo = this.dialogTree.GetDialogLine(this.currentDialogLineIndex);
        StartCoroutine(
            this.dialogBox.ShowDialog(
                dialogLineInfo.DialogLine,
                dialogLineInfo.SpeakerName,
                dialogLineInfo.Answers
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
        Debug.Log(this.currentDialogLineIndex);
        DialogLineInfo dialogLineInfo = this.dialogTree.GetDialogLine(this.currentDialogLineIndex);
        StartCoroutine(
            this.dialogBox.ShowDialog(
                dialogLineInfo.DialogLine,
                dialogLineInfo.SpeakerName,
                dialogLineInfo.Answers,
                onDone
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
