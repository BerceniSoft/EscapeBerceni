using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultDialogTree : AbstractDialogTree
{
    public override int OnDialogOptionPicked(int optionIndex, int dialogLineIndex)
    {
        // Return the next dialog line regardless the answer
        return dialogLineIndex + 1;
    }

    public override DialogLineInfo GetDialogLine(int dialogLineIndex)
    {
        if (dialogLineIndex == 0)
        {
            return new DialogLineInfo("Hello there!", "Eminescu", new List<string>());
        }
        else
        {
            List<string> answers = new List<string>();
            answers.Add("Answer A");
            answers.Add("Answer B");

            return new DialogLineInfo("What should I answer", "You", answers);
        }
    }
}
