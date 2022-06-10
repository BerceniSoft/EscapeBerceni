using Constants;
using Dialog;

namespace DialogTrees.Level0
{
    public class AfterEntranceDialogTree : AbstractDialogTree
    {
        public AfterEntranceDialogTree()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine = "Indiciile zilei sunt: Carol, Bellu, Tineretului, Copii și Brâncoveanu.",
                    SpeakerName = Speakers.Megaphone
                },
                new DialogLineInfo
                {
                    DialogLine =
                        "Hmm… Cred că se referă la Mausoleul din Parcul Carol, Cimitirul Bellu, Lacul Tineretului, Orășelul Copiilor și la stația de metrou Constantin Brâncoveanu.",
                    SpeakerName = Speakers.Player
                }
            };
        }
    }
}
