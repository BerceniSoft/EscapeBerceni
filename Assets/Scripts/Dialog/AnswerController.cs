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
    }

    public void OnOptionBPicked()
    {
        this.dialogManager.OnDialogOptionPicked(1);
        
    }
    public void OnOptionCPicked()
    {
        this.dialogManager.OnDialogOptionPicked(2);
        
    }
    public void OnOptionDPicked()
    {
        this.dialogManager.OnDialogOptionPicked(3);
        
    }


}
