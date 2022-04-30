using System;
using System.Collections.Generic;
using Constants;
using Dialog;

namespace DialogTrees
{
    public class IntroDialogTree : AbstractDialogTree
    {
        private void Awake()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine =
                        "Este anul 2025. La conducerea Bucureștiului se află o mână de tirani, care au decis că locuitorii cartierului Berceni reprezintă o rasă inferioră. Astfel, Berceni a fost complet împrejmuit cu un zid cum nici americanii n-au reușit să-și facă la graniță pentru a-i proteja pe ceilalți bucureșteni de „oamenii” din acest cartier.",
                },
                new DialogLineInfo
                {
                    DialogLine = "Totuși, pentru a-și dovedi dragostea lor nemărginită față de popor, membrii conducerii au decis să permită celor din Berceni să se integreze în societate… cu niște condiții.",
                },
                new DialogLineInfo
                {
                    DialogLine = "Ieșirea din Berceni se poate realiza doar prin intermediul metroului și este permisă doar celor care dau dovadă de un minim de înțelepciune și perseverență — în fiecare zi locuitorii Berceniului trebui să rezolve un set de puzzle-uri pentru a obține un cod care le permite să coboare din metrou la stații din afara cartierului.",
                },
                new DialogLineInfo
                {
                    DialogLine = "Acest test nu ar trebui să fie problemă pentru tine, căci ești un tânăr student care pornește spre facultate…",
                },
                new DialogLineInfo
                {
                    DialogLine = "Indiciile zilei sunt: Carol, Bellu, Tineretului, Copii și Brâncoveanu.",
                    SpeakerName = Speakers.Megaphone
                },
                new DialogLineInfo
                {
                    DialogLine = "Hmm… Cred că se referă la Mausoleul din Parcul Carol, Cimitirul Bellu, Lacul Tineretului, Orășelul Copiilor și la stația de metrou Constantin Brâncoveanu.",
                    SpeakerName = Speakers.Player
                },
            };
        }
    }
}
