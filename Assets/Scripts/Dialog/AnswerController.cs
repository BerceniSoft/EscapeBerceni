using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnswerController : MonoBehaviour
{
    public DialogManager dialogManager;


    public void OnOptionAPicked()
    {
        this.dialogManager.OnDialogOptionPicked(0);
        this.dialogManager.HideDialogBox();
        this.dialogManager.dialogBox.answersDialogBox.OnDone();
    }

    public void OnOptionBPicked()
    {
        this.dialogManager.OnDialogOptionPicked(1);
        this.dialogManager.HideDialogBox();
        this.dialogManager.dialogBox.answersDialogBox.OnDone();
    }

    public void OnOptionCPicked()
    {
        this.dialogManager.OnDialogOptionPicked(2);
        this.dialogManager.HideDialogBox();
        this.dialogManager.dialogBox.answersDialogBox.OnDone();
    }

    public void OnOptionDPicked()
    {
        this.dialogManager.OnDialogOptionPicked(3);
        this.dialogManager.HideDialogBox();
        this.dialogManager.dialogBox.answersDialogBox.OnDone();
    }
}