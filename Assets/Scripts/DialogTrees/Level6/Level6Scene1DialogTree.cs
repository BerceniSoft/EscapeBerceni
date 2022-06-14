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
                        "Salutări tinere călător. Ai avut un drum plin de înurcături. Să vedem daca te-ai descurcat!",
                    SpeakerName = Speakers.Barosan,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Pentru a trece de mine, este nevoie sa introduci codul. După, te voi lăsa să mergi la facultate ",
                    SpeakerName = Speakers.Barosan,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Care cod?",
                    SpeakerName = Speakers.Player,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Codul pe care l-ai strâns la etapele anterioare.",
                    SpeakerName = Speakers.Barosan,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Ok....",
                    SpeakerName = Speakers.Player,
                },
                
                new DialogLineInfo
                {
                    DialogLine =
                        "Cred că-mi amintesc.",
                    SpeakerName = Speakers.Player,
                },
                
                new DialogLineInfo
                {
                    DialogLine =
                        "Ai greșit! Ține minte...codul este format din literele pe care le-ai strâns la etapele anterioare.",
                    SpeakerName = Speakers.Barosan,
                },
                
                new DialogLineInfo
                {
                    DialogLine =
                        "Bravo, ai drum liber către facultate. Baftă... o să ai nevoie.",
                    SpeakerName = Speakers.Barosan,
                },
                
                new DialogLineInfo
                {
                    DialogLine =
                        "Gata. Poți să mergi la facultate. Ce mai vrei de la mine? Fugi până nu mă răzgândesc. Valea!",
                    SpeakerName = Speakers.Barosan,
                },
            };
        }
    }
}
