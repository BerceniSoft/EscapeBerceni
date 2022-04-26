using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLineInfo
{
    public string DialogLine {get;}
    public List<string> Answers {get;}
    public string SpeakerName {get;}

    public DialogLineInfo(string dialogLine, string speakerName, List<string> answers)
    {
        this.DialogLine = dialogLine;
        this.SpeakerName = speakerName;
        this.Answers = answers;
    }
}
