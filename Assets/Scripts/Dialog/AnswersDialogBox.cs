using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dialog
{
    public class AnswersDialogBox : MonoBehaviour
    {
        private readonly List<Answer> _answerBoxes = new();
        private TMP_Text _title;
        private Image _backgroundImage;
        private Action _currentOnDoneCallback;

        private void Start()
        {
            _backgroundImage = GetComponent<Image>();
            _title = GetComponentsInChildren<TMP_Text>()[0];

            // Get a reference to the AnswerGroup and create the Answer objects
            var answerGroup = transform.GetChild(1).gameObject;
            var backgroundImages = answerGroup.GetComponentsInChildren<Image>();
            var answerTexts = answerGroup.GetComponentsInChildren<TMP_Text>(); 
            var buttons = answerGroup.GetComponentsInChildren<Button>();

            for (var i = 0; i < 4; i++)
            {
                // Create the Answer objects with the corresponging callback
                _answerBoxes.Add(new Answer(answerTexts[i], backgroundImages[i], buttons[i]));
            }
        }

        public void ShowAnswers(List<string> answers)
        {
            _title.enabled = true;
            _backgroundImage.enabled = true;
        
            for (var i = 0; i < Mathf.Min(answers.Count, _answerBoxes.Count); i++)
            {
                _answerBoxes[i].ShowAnswer(answers[i]);
            }
        }

        public void ShowAnswers(List<string> answers, Action onDone)
        {
            _currentOnDoneCallback = onDone;
            ShowAnswers(answers);
        }

        public void HideAnswersDialogBox()
        {
            _title.enabled = false;
            _backgroundImage.enabled = false;
        
            foreach (var answer in _answerBoxes)
            {
                answer.HideAnswer();
            }
        }

        public void OnDone()
        {
            if (_currentOnDoneCallback != null)
            {
                _currentOnDoneCallback();
                _currentOnDoneCallback = null;
            }
        }
    }
}
