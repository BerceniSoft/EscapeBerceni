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
                }
            };
        }
    }
}
