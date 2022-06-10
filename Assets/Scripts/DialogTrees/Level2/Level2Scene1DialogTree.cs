using System;
using System.Collections.Generic;
using Constants;
using Dialog;

namespace DialogTrees
{
    public class Level2Scene1DialogTree : AbstractDialogTree
    {
        private void Awake()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine =
                        "Salutări tinere călător. Bine ai venit la locul meu de veci, domeniul intelectualității eterne unde creativitatea și inteligența umană prosperă în eternitate.",
                    SpeakerName = Speakers.Eminescu,
                },
                new DialogLineInfo
                {
                    DialogLine = "... Aolo ăsta e Eminescu... Nici la facultate nu scap de el.",
                    SpeakerName = Speakers.Player,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Tinere drag, ce te aduce pe aceste meleaguri? Puțini cutează să se aventureze prin asemenea locuri dezolante fiindu-le frică de dominanța simbolului morții de peste acest spațiu restrâns.",
                    SpeakerName = Speakers.Eminescu
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Ahm... bună ziua, domnule Eminescu... condoleanțe... Mergeam la facultate, dar nu pot coborî la metrou.",
                    SpeakerName = Speakers.Player
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Ah! În drumul tău către cultivarea sinelui intelectual. Apreciez dorința de cunoaștere. Știu de ce ai nevoie în călătoria ta. Dar mai întâi, te voi supune la un test pentru a vedea dacă ești vrednic pentru calea cunoașterii.",
                    SpeakerName = Speakers.Eminescu
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Alege una din aceste opere celebre scrise de geniul meu pe care să o reciți pentru a-mi demonstra nivelul tău de cultură.",
                    SpeakerName = Speakers.Eminescu,
                    Answers = new List<(string, int)>
                    {
                        ("Luceafărul", 6),
                        ("Ce te legeni?", 6),
                        ("Dorința", 6),
                        ("Scrisoarea III", 6)
                    }
                },
                new DialogLineInfo
                {
                    DialogLine = "Pff... da' cine mai știe poezia asta...",
                    SpeakerName = Speakers.Player
                },
                new DialogLineInfo
                {
                    DialogLine = "Și așa... am mai picat pe unu'.",
                    SpeakerName = Speakers.Eminescu
                }
            };
        }
    }
}
