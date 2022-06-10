using TMPro;
using UnityEngine.UI;

namespace Dialog
{
    public class Answer
    {
        private readonly TMP_Text _text;
        private readonly Image _background;
        private readonly Button _button;

        public Answer(TMP_Text text, Image image, Button button) 
        {
            _text = text;
            _background = image;
            _button = button;
        }

        public void ShowAnswer(string option)
        {
            _text.text = option;
            _text.enabled = true;
            _background.enabled = true;
            _button.enabled = true;
        }

        public void HideAnswer()
        {
            _text.text = "";
            _text.enabled = false;
            _background.enabled = false;
            _button.enabled = false;
        }
    }
}
