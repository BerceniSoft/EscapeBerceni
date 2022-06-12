using System;
using System.Collections.Generic;
using Constants;
using Dialog;

namespace DialogTrees
{
    public class Level4Scene3DialogTree : AbstractDialogTree
    {
        private void Awake()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine =
                        "Ieeei! Ce frumos a fost! Acum vreau sa merg la mami!",
                    SpeakerName = Speakers.Isabela,
                },
                new DialogLineInfo
                {
                    DialogLine = "Mai stii unde ai lasat-o ultima oara?",
                    SpeakerName = Speakers.Player,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Pe aici pe undeva, la topogane..",
                    SpeakerName = Speakers.Isabela,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Hmm... Hai sa mergem sa incercam sa o gasim.",
                    SpeakerName = Speakers.Player,
                    
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Isabela!! Aici erai! Sa nu mai pleci de langa noi! Multumim tinere, credeam ca am pierdut-o, iti ramanem vesnic recunoscatori!",
                    SpeakerName = Speakers.Mom1,
                },
                new DialogLineInfo
                {
                    DialogLine = 
                        "Uite un bilet cu numarul meu, daca ai nevoie de ceva suna-ne oricand.",
                    SpeakerName = Speakers.Mom1
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Cu drag! A fost cuminte, sa stiti.",
                    SpeakerName = Speakers.Player,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Alex, nu te duce in topoganul inalt! O sa te julesti!",
                    SpeakerName = Speakers.Mom2,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Hm, nu cred ca e ea.",
                    SpeakerName = Speakers.Player,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Ce vreme frumoasa de iesit afara e azi! De-ar fi mereu asa..",
                    SpeakerName = Speakers.Mom3
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Hm, nu cred ca e ea.",
                    SpeakerName = Speakers.Player,
                },
            };
        }
    }
}