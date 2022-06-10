using System;
using System.Collections.Generic;
using Constants;
using Dialog;

namespace DialogTrees
{
    public class Level3Scene3DialogTree : AbstractDialogTree
    {
        private void Awake()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine =
                        "Salut, şefule, văd că ai văzut raţă.",
                    SpeakerName = Speakers.Boschetar1
                },
                new DialogLineInfo
                {
                    DialogLine = "Pune-o pe grătar!",
                    SpeakerName = Speakers.Boschetar2,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Poftim!",
                    SpeakerName = Speakers.Player
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Mersi, șefule, o să mâncăm raţa asta cu muștar. Poftim litera! Drum bun cu metroul!",
                    SpeakerName = Speakers.Boschetar1
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Pofta bună, băieți.",
                    SpeakerName = Speakers.Player
                },
            };
        }
    }
}
