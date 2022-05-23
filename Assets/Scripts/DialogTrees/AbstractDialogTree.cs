using Dialog;
using UnityEngine;

namespace DialogTrees
{
    public abstract class AbstractDialogTree : MonoBehaviour
    {
        protected DialogLineInfo[] dialogLineInfos;

        public DialogLineInfo[] DialogLineInfos => dialogLineInfos;

        /**
         * <summary>Implement to handle dialog option pick when a dialog box is shown</summary>
         * <returns>The index of dialog line to skip to</returns>
         */
        public int OnDialogOptionPicked(int optionIndex, int dialogLineIndex)
        {
            return dialogLineInfos[dialogLineIndex].Answers[optionIndex].Item2;
        }

        /**
        * <summary>Define what's the dialog line to be show for this index</summary>
        */
        public DialogLineInfo GetDialogLine(int dialogLineIndex)
        {
            if (dialogLineIndex > dialogLineInfos.Length || dialogLineIndex < 0)
            {
                return null;
            }

            return dialogLineInfos[dialogLineIndex];
        }
    }
}
