using System.Collections.Generic;
using Constants;

namespace Dialog
{
    public class DialogLineInfo
    {
        public string DialogLine { get; set; }
        public List<(string, int)> Answers { get; set; }
        public string SpeakerName { get; set; } = Speakers.Narrator;
    }
}
