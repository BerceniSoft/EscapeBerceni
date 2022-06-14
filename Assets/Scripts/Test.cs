using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Dialog;

public class Test : MonoBehaviour
{
    public DialogManager dialogManager;

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            dialogManager.ShowDialog();
        }
    }
}
