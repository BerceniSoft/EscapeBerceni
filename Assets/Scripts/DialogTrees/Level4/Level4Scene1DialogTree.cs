using System;
using System.Collections.Generic;
using Constants;
using Dialog;

namespace DialogTrees
{
    public class Level4Scene1DialogTree : AbstractDialogTree
    {
        private void Awake()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine =
                        "M-am pierdut de mami si tati :(((((((",
                    SpeakerName = Speakers.Isabela,
                },
                new DialogLineInfo
                {
                    DialogLine = "Oh... Imi pare rau...",
                    SpeakerName = Speakers.Player,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Ma ajuti sa ii gasesc?",
                    SpeakerName = Speakers.Isabela,
                    Answers = new List<(string, int)>
                    {
                        ("Da", 3),
                        ("Nu", 2)
                    }
                },
                new DialogLineInfo
                {
                    DialogLine = "Sigur, cu conditia sa fii cuminte.",
                    SpeakerName = Speakers.Player,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Da-ma in roata te rog!",
                    SpeakerName = Speakers.Isabela
                }
            };
        }
    }
}
