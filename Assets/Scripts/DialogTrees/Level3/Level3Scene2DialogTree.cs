using System;
using System.Collections.Generic;
using Constants;
using Dialog;

namespace DialogTrees
{
    public class Level3Scene2DialogTree : AbstractDialogTree
    {
        private void Awake()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine =
                        "Bună ziua, ați putea să mă ajutați cu ceva?",
                    SpeakerName = Speakers.Player
                },
                new DialogLineInfo
                {
                    DialogLine = "Da, tinere, cu ce anume?",
                    SpeakerName = Speakers.Pescar,
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Puteți să mă ajutați să prind raţa aia de pe lac?",
                    SpeakerName = Speakers.Player
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Da, tinere, dar trebuie să mă ajuţi cu integralele astea.",
                    SpeakerName = Speakers.Pescar
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Aoleu, integrale?",
                    SpeakerName = Speakers.Player
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Da, tinere. Uite:",
                    SpeakerName = Speakers.Pescar
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "∫(tgx * tgy * (z + ln(t) * lg(u)) dx dy dz dt du",
                    SpeakerName = Speakers.Pescar
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Nu știu eu d-astea, domnule",
                    SpeakerName = Speakers.Player
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Am glumit, cu niște integrame vreau sa ma ajuți!",
                    SpeakerName = Speakers.Pescar
                },
                new DialogLineInfo 
                {
                    DialogLine =
                        "Ce a fost Aurel Vlaicu?",
                    SpeakerName = Speakers.Pescar,
                    Answers = new List<(string, int)>
                    {
                        ("Poet", 10),
                        ("Actor", 10),
                        ("Aviator", 11),
                        ("Brutar", 10)
                    }
                },
                new DialogLineInfo 
                {
                    DialogLine =
                        "Cand a murit Bogdan Petriceicu Hasdeu?",
                    SpeakerName = Speakers.Pescar,
                    Answers = new List<(string, int)>
                    {
                        ("1608", 11),
                        ("1807", 11),
                        ("1850", 11),
                        ("1907", 12)
                    }
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Cine a scris Ultima noapte de dragoste intaia noapte de razboi?",
                    SpeakerName = Speakers.Pescar,
                    Answers = new List<(string, int)>
                    {
                        ("Camin Petrescu", 13),
                        ("Mihai Eminescu", 12),
                        ("Ion-Luca Caragiale", 12),
                        ("Tudor Arghezi", 12)
                    }
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Felicitări, tinere! Meulţumesc pentru ajutor!",
                    SpeakerName = Speakers.Pescar
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Cu plăcere!",
                    SpeakerName = Speakers.Player
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Poftim raţa, spor la facultate!",
                    SpeakerName = Speakers.Pescar
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Mac,mac!",
                    SpeakerName = Speakers.Rata
                },
            };
        }
    }
}
