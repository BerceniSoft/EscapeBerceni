using Constants;
using Dialog;

namespace DialogTrees
{
    public class Level3Scene2DialogTree : AbstractDialogTree
    {
        public Level3Scene2DialogTree()
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
