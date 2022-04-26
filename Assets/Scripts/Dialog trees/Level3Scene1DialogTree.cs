using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Scene1DialogTree : AbstractDialogTree
{
    public override int OnDialogOptionPicked(int optionIndex, int dialogLineIndex)
    {
        if (dialogLineIndex == 0)
        {
            return 1;
        }

        return 0;
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
            answers.Add("General kenobi");
            answers.Add("General Kenobi");

            return new DialogLineInfo("Oh shit", "Tu", answers);
        }
    }
}
