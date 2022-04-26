using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using TMPro;
using UnityEngine.UI;

public class AnswersDialogBox : MonoBehaviour
{
    private List<Answer> answerBoxes = new List<Answer>();
    private TMP_Text title;
    private Image backgroundImage;

    // Start is called before the first frame update
    void Start()
    {
        this.backgroundImage = this.GetComponent<Image>();
        this.title = this.GetComponentsInChildren<TMP_Text>()[0];

        // Get a reference to the AnswerGroup and create the Answer objects
        GameObject answerGroup = this.transform.GetChild(0).gameObject;
        Image[] backgroundImages = answerGroup.GetComponentsInChildren<Image>();
        TMP_Text[] answerTexts = answerGroup.GetComponentsInChildren<TMP_Text>(); 
        Button[] buttons = answerGroup.GetComponentsInChildren<Button>();

        //TODO: Grab the buttons

        for(int i=0;i<4;i++)
        {
            // Create the Answer objects with the corresponging callback
            // TODO: Pass in the buttons
            //TODO: Register the event handler
            this.answerBoxes.Add(new Answer(answerTexts[i], backgroundImages[i], buttons[i]));
        }
    }


    public void ShowAnswers(List<string> answers)
    {
        this.title.enabled = true;
        this.backgroundImage.enabled = true;
        for(int i=0;i<Mathf.Min(answers.Count, this.answerBoxes.Count);i++)
        {
            this.answerBoxes[i].ShowAnswer(answers[i]);
        }
    }

    private void HideAnswersDialogBox()
    {
        this.title.enabled = false;
        this.backgroundImage.enabled = false;
        foreach(Answer answer in this.answerBoxes)
        {
            answer.HideAnswer();
        }
    }

}
