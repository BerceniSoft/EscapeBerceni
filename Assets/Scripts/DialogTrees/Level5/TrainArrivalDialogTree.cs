using Constants;
using Dialog;

namespace DialogTrees.Level5
{
    public class TrainArrivalDialogTree : AbstractDialogTree
    {
        private void Awake()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine = "Ia uite, vine metroul.",
                    SpeakerName = Speakers.Player
                },
                new DialogLineInfo
                {
                    DialogLine = "În sfârșit o să scap!",
                    SpeakerName = Speakers.Player
                }
            };
        }
    }
}