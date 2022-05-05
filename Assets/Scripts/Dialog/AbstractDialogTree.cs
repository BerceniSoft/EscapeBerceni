using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDialogTree:MonoBehaviour
{
    
    /**
    * Implement to handle dialog option pick when a dialog box is shown
        @returns The index of dialog line to skip to
    */
    abstract public int OnDialogOptionPicked(int optionIndex, int dialogLineIndex);

    /**
    * Define what's the dialog line to be show for this index
    */
    abstract public DialogLineInfo GetDialogLine(int dialogLineIndex);
 
}
