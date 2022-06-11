using System;
using System.Collections.Generic;
using Constants;
using Dialog;

namespace DialogTrees
{
    public class Level6Scene1DialogTree : AbstractDialogTree
    {
        private void Awake()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine =
                        "Salutări tinere călător. Acum ca ai ajuns aproape la final am nevoie de la tine sa introduci codul pe care l-ai cules.",
                    SpeakerName = Speakers.Keypad,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "2 ",
                    SpeakerName = Speakers.Keypad,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "3",
                    SpeakerName = Speakers.Keypad,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "4",
                    SpeakerName = Speakers.Keypad,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "5",
                    SpeakerName = Speakers.Keypad,
                },
            };
        }
    }
}
