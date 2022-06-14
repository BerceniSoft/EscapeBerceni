using System;
using System.Collections.Generic;
using Constants;
using Dialog;

namespace DialogTrees
{
    public class Level6Scene2DialogTree : AbstractDialogTree
    {
        private void Awake()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine =
                        "1!",
                    SpeakerName = Speakers.Barosan,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "2! ",
                    SpeakerName = Speakers.Barosan,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "3!",
                    SpeakerName = Speakers.Barosan,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "4!",
                    SpeakerName = Speakers.Barosan,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "5!",
                    SpeakerName = Speakers.Barosan,
                },
            };
        }
    }
}
