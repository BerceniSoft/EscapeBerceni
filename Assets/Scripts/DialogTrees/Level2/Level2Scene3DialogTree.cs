using Constants;
using Dialog;

namespace DialogTrees.Level2
{
    public class Level2Scene3DialogTree : AbstractDialogTree
    {
        public Level2Scene3DialogTree()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    SpeakerName = Speakers.EminescuGrave,
                    DialogLine = "Aici se odihneste marele poet roman"
                },
                new DialogLineInfo()
                {
                    DialogLine = "Nu pot sa cred ca iar a scapat... oare unde s-a dus de data asta fantoma lui Eminescu.",
                    SpeakerName = Speakers.Preot
                },
                new DialogLineInfo()
                {
                    DialogLine = "Ahm.. imi cer scuze...domnule preot?!",
                    SpeakerName = Speakers.Player
                },
                new DialogLineInfo()
                {
                    DialogLine = "Da tinere! Ce doresti?",
                    SpeakerName = Speakers.Preot
                },
                new DialogLineInfo()
                {
                    DialogLine = "Pe el il cautati?",
                    SpeakerName = Speakers.Player
                },
                new DialogLineInfo()
                {
                    DialogLine = "Fantoma lui Eminescu! Aici era! Repede, nu e timp de pierdut, trebuie exorcizat",
                    SpeakerName = Speakers.Preot
                },
                new DialogLineInfo()
                {
                    DialogLine = "Haide dom' parinte! Mai lasa-ma si pe mine 5 minute la aer",
                    SpeakerName = Speakers.Eminescu
                },
                new DialogLineInfo()
                {
                    DialogLine =
                        "Asa ai zis si data trecuta si ai bantuit-o pe Ana Blandiana o saptamana ca nu iti placea poezia ei. Nici o sansa. ",
                    SpeakerName = Speakers.Preot
                },
                new DialogLineInfo()
                {
                    DialogLine = "In numele Tatalui, si al Fiului, si al Sfantului Duh.... Exorcizare!",
                    SpeakerName = Speakers.Preot
                },
                new DialogLineInfo()
                {
                    DialogLine = "Afurisit sa fii Perry... adica Preotul din Berceni!!",
                    SpeakerName = Speakers.Eminescu
                },
                new DialogLineInfo()
                {
                    DialogLine = "Asa. Am scapat de el. Acum poti merge linistit in treba ta tinere. Poftin, poate o sa ai nevoie de asta daca doresti sa mergi astazi cu metroul",
                    SpeakerName = Speakers.Preot
                },
            };
        }
    }
}