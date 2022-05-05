using System.Collections.Generic;

namespace Dialog
{
    public class DialogLineInfo
    {
        public string DialogLine { get; }
        public List<string> Answers { get; }
        public string SpeakerName { get; }

        public DialogLineInfo(string dialogLine, string speakerName, List<string> answers)
        {
            DialogLine = dialogLine;
            SpeakerName = speakerName;
            Answers = answers;
        }
    }
}
