using System.Collections;
using System.Collections.Generic;
using Dialog;
using DialogTrees;
using UnityEngine;

public class Level3Scene3DialogTree1 : AbstractDialogTree
{
    public override int OnDialogOptionPicked(int optionIndex, int dialogLineIndex)
    {
        throw new System.NotImplementedException();
    }

    public override DialogLineInfo GetDialogLine(int dialogLineIndex)
    {
        switch (dialogLineIndex)
        {
            case 0:
            {
                return new DialogLineInfo("Aici se odihn")
            }
        }
    }
}
