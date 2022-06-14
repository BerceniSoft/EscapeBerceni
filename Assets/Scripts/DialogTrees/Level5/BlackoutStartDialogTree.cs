using System;
using Constants;
using Dialog;

namespace DialogTrees.Level5
{
    public class BlackoutStartDialogTree : AbstractDialogTree
    {
        private void Awake()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine = "Aoleu, Doamne, nu mai văd nimic și nu-i de la cataractă!",
                    SpeakerName = Speakers.OldLady
                }
            };
        }
    }
}