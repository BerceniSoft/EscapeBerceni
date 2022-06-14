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
                        "Salutări tinere student! Bine ai venit la facultate! Ai întârziat mult astăzi.",
                    SpeakerName = Speakers.Profesor,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Bună ziua...mă scuzați...",
                    SpeakerName = Speakers.Player,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "De ce ai întârziat?",
                    SpeakerName = Speakers.Profesor,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Astăzi a fost dificil să obţin accesul la metrou pentru a evada din Berceni.",
                    SpeakerName = Speakers.Player,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Ok, acum hai să mergem. Trebuie să prezinţi proiectul!",
                    SpeakerName = Speakers.Profesor,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Desigur!",
                    SpeakerName = Speakers.Player,
                },
            };
        }
    }
}