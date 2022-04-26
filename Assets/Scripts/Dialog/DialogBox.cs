using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{ 
   public string dialog = "";
   public float typeSpeed = 50;
   // the actual text that is displayed now
   private List<string> tokens;
   private int TOKEN_LENGTH = 150;
   private int displayedToken = 0;
   private bool showNextToken = false;

   private TMP_Text dialogText;
   private Image dialogBoxImage;
   private Image showMoreIcon;
   private TMP_Text speakerName;


// Start is called before the first frame update
    void Start()
    {
        Image[] images = this.gameObject.GetComponentsInChildren<Image>();
        TMP_Text[] texts = this.gameObject.GetComponentsInChildren<TMP_Text>();
        this.dialogText = texts[0];
        this.speakerName = texts[1];
        this.dialogBoxImage = images[0];
        this.showMoreIcon = images[1];

    }

    private void ShowDialogBox(){
        this.speakerName.enabled = true;
        this.dialogText.enabled = true;
        this.dialogBoxImage.enabled = true;
    }

    private void HideDialogBox(){
        this.dialogText.enabled = false;
        this.speakerName.enabled = false;
        this.dialogBoxImage.enabled = false;
    }

    private void EnableShowMoreIcon(){
        this.showMoreIcon.enabled = true;
    }

    private void DisableShowMoreIcon(){
        this.showMoreIcon.enabled = false;
    }

    public void ShowDialog(string text, string speakerName)
    {
        this.dialog = text;
        List<string> _tokens = new List<string>();
        this.displayedToken = 0;
        
        for (int i = 0; i < this.dialog.Length; i = i + this.TOKEN_LENGTH)
        {
            if(i + this.TOKEN_LENGTH <= this.dialog.Length)
            {
                _tokens.Add(this.dialog.Substring(i, this.TOKEN_LENGTH));
            }
            else
            {
                _tokens.Add(this.dialog.Substring(i));

            }
        }

        this.tokens = _tokens;
        
        // Set the speaker name
        this.speakerName.text = speakerName;

        // Enable the dialog box and start the animation

        this.ShowDialogBox();
        StartCoroutine(this.TypeToken(this.tokens[0]));
        
    }

    private IEnumerator TypeToken(string token)
    {
        if (this.dialogText == null)
        {
            yield break;
        }

        yield return new WaitForSeconds(0.2f);
        
        float timePassed = 0;
        int charIndex = 0;


        while (charIndex < token.Length)
        {
            timePassed += Time.deltaTime * this.typeSpeed;
            charIndex = Mathf.FloorToInt(timePassed);
            charIndex = Mathf.Clamp(charIndex, 0, token.Length);
            this.dialogText.text = token.Substring(0, charIndex);
            yield return null;
        }

        this.dialogText.text = token;
        
        // Increment this to signal that we should wait for the input to show the next token from the dialog
        this.displayedToken++;
        this.showNextToken = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.showNextToken)
        {
            if (this.displayedToken < this.tokens.Count)
            {
                // Show the arrow if there is more text
                this.EnableShowMoreIcon();
            }

            if (Input.GetKeyUp("space"))
            {
                this.showNextToken = false;
                if (this.displayedToken < this.tokens.Count)
                {
                    this.DisableShowMoreIcon();
                    StartCoroutine(this.TypeToken(this.tokens[this.displayedToken]));
                }
                else
                {
                    // Finished the text so hide the dialog
                    this.DisableShowMoreIcon();
                    this.HideDialogBox();           
                    this.dialogText.text = "";
                }
            }
        }
        
    }
}
