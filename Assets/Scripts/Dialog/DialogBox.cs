using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dialog
{
    public class DialogBox : MonoBehaviour
    {
        private const int TokenLength = 150;

        public string dialog = "";
        public float typeSpeed = 50;
        public AnswersDialogBox answersDialogBox;

        // The actual text that is displayed now
        private List<string> _tokens;
        private int _displayedToken;
        private bool _showNextToken;
        private bool _skipWriting;

        private TMP_Text _dialogText;
        private Image _dialogBoxImage;
        private Image _showMoreIcon;
        private TMP_Text _speakerName;
        private TMP_Text _showMoreText;
        private Action _doneCallback;

        // If this is non empty, after the end we'll show an answer dialog box
        private List<string> _answers;

        private void Awake()
        {
            var images = gameObject.GetComponentsInChildren<Image>();
            var texts = gameObject.GetComponentsInChildren<TMP_Text>();

            _dialogText = texts[0];
            _speakerName = texts[1];
            _showMoreText = texts[2];
            _dialogBoxImage = images[0];
            _showMoreIcon = images[1];
        }

        private void ShowDialogBox()
        {
            _speakerName.enabled = true;
            _dialogText.enabled = true;
            _dialogBoxImage.enabled = true;
            _showMoreText.enabled = true;
        }

        public void HideDialogBox()
        {
            _dialogText.enabled = false;
            _speakerName.enabled = false;
            _dialogBoxImage.enabled = false;
            _showMoreText.enabled = false;

            answersDialogBox.HideAnswersDialogBox();
            DisableShowMoreIcon();
        }

        private void EnableShowMoreIcon()
        {
            _showMoreIcon.enabled = true;
        }

        private void DisableShowMoreIcon()
        {
            _showMoreIcon.enabled = false;
        }

        public IEnumerator ShowDialog(string text, string speakerName, List<string> answers)
        {
            dialog = text;
            _answers = answers;
            _tokens = new List<string>();
            _displayedToken = 0;

            var words = dialog.Split();
            var token = string.Empty;
            foreach (var word in words)
            {
                if (token.Length + word.Length + 1 > TokenLength)
                {
                    _tokens.Add(token);
                    token = word;
                }
                else
                {
                    token += $" {word}";
                }
            }

            _tokens.Add(token);

            // Set the speaker name
            _speakerName.text = speakerName;

            // Enable the dialog box and start the animation
            ShowDialogBox();
            yield return StartCoroutine(TypeToken(_tokens[0]));
        }

        public IEnumerator ShowDialog(string text, string speakerName, List<string> answers, Action onDone)
        {
            _doneCallback = onDone;
            yield return ShowDialog(text, speakerName, answers);
        }

        private IEnumerator TypeToken(string token)
        {
            _skipWriting = false;

            if (_dialogText == null)
            {
                yield break;
            }

            yield return new WaitForSeconds(0.2f);

            var timePassed = 0f;
            var charIndex = 0;

            while (charIndex < token.Length && !_skipWriting)
            {
                timePassed += Time.deltaTime * typeSpeed;
                charIndex = Mathf.FloorToInt(timePassed);
                charIndex = Mathf.Clamp(charIndex, 0, token.Length);
                _dialogText.text = token[..charIndex];
                yield return null;
            }

            _dialogText.text = token;

            // Increment this to signal that we should wait for the input to show the next token from the dialog or close the window
            _displayedToken++;
            _showNextToken = true;
        }

        // Update is called once per frame
        private void Update()
        {
            if (_showNextToken)
            {
                if (_displayedToken < _tokens.Count)
                {
                    // Show the arrow if there is more text
                    EnableShowMoreIcon();
                }

                if (Input.GetKeyUp("space"))
                {
                    _showNextToken = false;
                    if (_displayedToken < _tokens.Count)
                    {
                        DisableShowMoreIcon();
                        StartCoroutine(TypeToken(_tokens[_displayedToken]));
                    }
                    else
                    {
                        // Finished the text so hide the dialog
                        DisableShowMoreIcon();
                        HideDialogBox();
                        _dialogText.text = "";

                        if (_answers != null && _answers.Count != 0)
                        {
                            answersDialogBox.ShowAnswers(_answers, _doneCallback);
                        }
                        else if (_doneCallback != null)
                        {
                            // Dialog ended, call the last cb

                            var callback = _doneCallback;
                            // Clear the saved callback before calling it instead of after
                            // This will prevent a succesive dialog box from having its callback cleared
                            _doneCallback = null;
                            callback();
                        }
                    }
                }
            }
            else if (Input.GetKeyUp("space"))
            {
                _skipWriting = true;
            }
        }
    }
}