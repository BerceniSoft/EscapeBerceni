using System;
using Constants;
using Dialog;

namespace DialogTrees.Level5
{
    public class AfterBlackoutDialogTree : AbstractDialogTree
    {
        private void Awake()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine =
                        "Vai, mamaie, dar pe lângă frumos mai ești și deștept! Ptiu, să nu te deochi! Ia, flăcău, foița asta că am găsit-o pe aici prin stație. E de la Partid, să te lase nenorociții ăia, maică, să ieși în lume!",
                    SpeakerName = Speakers.OldLady
                }
            };
        }
    }
}