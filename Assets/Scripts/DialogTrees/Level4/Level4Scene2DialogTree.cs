using System;
using System.Collections.Generic;
using Constants;
using Dialog;

namespace DialogTrees
{
    public class Level4Scene2DialogTree : AbstractDialogTree
    {
        private void Awake()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine =
                        "Ehe! Din pacate inchidem roata in ziua asta frumoasa, poate alta data.",
                    SpeakerName = Speakers.OmRoata,
                },
                new DialogLineInfo
                {
                    DialogLine = "O nu! Ce s-a intamplat?",
                    SpeakerName = Speakers.Player,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Doar de-ar merge calculatorul asta…",
                    SpeakerName = Speakers.OmRoata,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Conexiune intrerupta... SelEcTAti paRolA:",
                    SpeakerName = Speakers.Calculator,
                    Answers = new List<(string, int)>
                    {
                        ("setara", 4),
                        ("etara", 3),
                        ("elctia", 3),
                        ("setra", 3)
                    }
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Bine ai venit, jucatorule! Pentru a ma pune inapoi in functiune, trebuie sa rezolvi cateva ghicitori.",
                    SpeakerName = Speakers.Calculator,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Asadar, prima ghicitoare. Cu ce se hranesc calculatoarele?",
                    SpeakerName = Speakers.Calculator,
                    Answers = new List<(string, int)>
                    {
                        ("Cabluri", 5),
                        ("Cookies", 6),
                        ("Baterii", 5)
                    }
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Un inceput bun... Dar, cati biti are un octet?",
                    SpeakerName = Speakers.Calculator,
                    Answers = new List<(string, int)>
                    {
                        ("5", 6),
                        ("3", 6),
                        ("8", 7)
                    }
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Esti descurcaret, deci! Cat noroc cu tine!",
                    SpeakerName = Speakers.OmRoata
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Pentru ca te-ai descurcat asa bine pana acum, vei fi provocat la un joc de gandire!",
                    SpeakerName = Speakers.Calculator
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Intrebare finala, cate anagrame are cuvantul \"aparte\"?",
                    SpeakerName = Speakers.Calculator,
                    Answers = new List<(string, int)>
                    {
                        ("6", 10),
                        ("3", 9),
                        ("8", 9)
                    }
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Felicitari! Conexiune restabilita!",
                    SpeakerName = Speakers.Calculator,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Ehe! Multumesc, tinere! Drept rasplata, iti ofer o tura gratis in roata pentru tine si pustoaica ta!",
                    SpeakerName = Speakers.OmRoata,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Vino sa te dai in cea mai amuzanta si zguduitoare cursa!",
                    SpeakerName = Speakers.BumperCar,
                },
                new DialogLineInfo
                {
                    DialogLine = "O nu! Ce s-a intamplat?",
                    SpeakerName = Speakers.Player,
                },
            };
        }
    }
}