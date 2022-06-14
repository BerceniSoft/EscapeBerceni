using System;
using System.Collections.Generic;
using Constants;
using Dialog;

namespace DialogTrees
{
    public class Level3Scene1DialogTree : AbstractDialogTree
    {
        private void Awake()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine =
                        "Ce faci, șefule, ai o țigară?",
                    SpeakerName = Speakers.Boschetar1,
                },
                new DialogLineInfo
                {
                    DialogLine = "Doua țigări, sefule.",
                    SpeakerName = Speakers.Boschetar2,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Nu am, îmi pare rău.",
                    SpeakerName = Speakers.Player
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Știi ce nu mai ai, ma? Acces la metrou și nici n o sa ai.",
                    SpeakerName = Speakers.Boschetar1
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Știți cum sa obțin accesul pentru astăzi?",
                    SpeakerName = Speakers.Player
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Da, bossule. Dar trebuie să faci ceva pt noi dacă vrei să îți spunem.",
                    SpeakerName = Speakers.Boschetar2
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Da, trebuie să ne dai bani, toți banii pe care ii ai.",
                    SpeakerName = Speakers.Boschetar1
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Nu am bani la mine :(((",
                    SpeakerName = Speakers.Player
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Atunci trebuie să ne aduci mâncare. Poți să prinzi o raţa să o facem pe grătarul ăsta.",
                    SpeakerName = Speakers.Boschetar2
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Bine, aşa o să fac!",
                    SpeakerName = Speakers.Player
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Baftă, bossule.",
                    SpeakerName = Speakers.Boschetar1
                },
            };
        }
    }
}
