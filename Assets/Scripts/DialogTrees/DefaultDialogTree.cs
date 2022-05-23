using System;
using Dialog;

namespace DialogTrees
{
    public class DefaultDialogTree : AbstractDialogTree
    {
        private void Awake()
        {
            dialogLineInfos = new[]
            {
                new DialogLineInfo
                {
                    DialogLine = "THIS IS FOR DEVELOPMENT PURPOSES ONLY."
                },
                new DialogLineInfo
                {
                    DialogLine = "Ce cauți aici?"
                }
            };
        }
    }
}
