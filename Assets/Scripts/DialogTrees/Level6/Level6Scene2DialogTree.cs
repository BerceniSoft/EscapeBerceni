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
                        "Bună-ziua...errmm...mă scuzați... am fost printr-o... aventură...  ",
                    SpeakerName = Speakers.Player,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Cum așa?",
                    SpeakerName = Speakers.Profesor,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Nici nu pot să vă descriu! A trebuit să rezolv tot felul de puzzle-uri si joculețe pentru a putea ajunge la metrou.",
                    SpeakerName = Speakers.Player,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "De abia aștept să-mi povestești mai multe",
                    SpeakerName = Speakers.Profesor,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "A fost ca un vis...nici nu vă puteți imagina",
                    SpeakerName = Speakers.Player,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Ok, acum hai să mergem. Avem treabă!",
                    SpeakerName = Speakers.Profesor,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Hai!",
                    SpeakerName = Speakers.Player,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Vin si eu după tine imediat! Ia-o înainte",
                    SpeakerName = Speakers.Profesor,
                },
            };
        }
    }
}
