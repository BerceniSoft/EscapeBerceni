using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Answer
{
    private TMP_Text text;
    private Image background;
    private Button button;

    public Answer(TMP_Text text, Image image, Button button){
        this.text = text;
        this.background = image;
        this.button = button;

    }

    public void ShowAnswer(string option)
    {
        this.text.text = option;
        this.text.enabled = true;
        this.background.enabled = true;
        this.button.enabled = true;
    }

    public void HideAnswer()
    {
        this.text.text = "";
        this.text.enabled = true;
        this.background.enabled = true;
        this.button.enabled = false;

    }

}
