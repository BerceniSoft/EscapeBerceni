using Constants;
using Dialog;

namespace DialogTrees.Level2
{
    public class Level2Scene2DialogTree : AbstractDialogTree
    {
        public Level2Scene2DialogTree()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine = "Nu poți fugi de mine, tinere!",
                    SpeakerName = Speakers.Eminescu
                },
                new DialogLineInfo
                {
                    DialogLine = "(1882-1913) - Inginer, inventator și aviator, membru al Academiei Române",
                    SpeakerName = Speakers.Grave1
                },
                new DialogLineInfo
                {
                    DialogLine = "(1838-1907) - Enciclopedist, scriitor, filolog, lingvist, jurist, folclorist, publicist, istoric, politician și membru al Academiei Române",
                    SpeakerName = Speakers.Grave2
                },
                new DialogLineInfo
                {
                    DialogLine = "(1894-1957) - Poet, prozator și dramaturg, membru al Academiei Române",
                    SpeakerName = Speakers.Grave3
                }
            };
        }
    }
}
