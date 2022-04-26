using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{

    protected int currentDialogLineIndex;
    public DialogBox dialogBox;
    public AbstractDialogTree dialogTree;
    public AnswersDialogBox answersDialogBox;

    // Start is called before the first frame update
    void Start()
    {
        this.currentDialogLineIndex = 0;
    }

    public void ShowDialog()
    {
        DialogLineInfo dialogLineInfo = this.dialogTree.GetDialogLine(this.currentDialogLineIndex);
        this.dialogBox.ShowDialog(dialogLineInfo.DialogLine, dialogLineInfo.SpeakerName);

        if(dialogLineInfo.Answers.Count > 0)
        {
            this.answersDialogBox.ShowAnswers(dialogLineInfo.Answers);
        }

    
    }


    public void OnDialogOptionPicked(int optionIndex)
    {
        this.currentDialogLineIndex =  this.dialogTree.OnDialogOptionPicked(optionIndex, this.currentDialogLineIndex);
    }




    
}
