using Dialog;
using UnityEngine;

namespace DialogTrees
{
    public abstract class AbstractDialogTree : MonoBehaviour
    {
        /**
         * <summary>Implement to handle dialog option pick when a dialog box is shown</summary>
         * <returns>The index of dialog line to skip to</returns>
         */
        public abstract int OnDialogOptionPicked(int optionIndex, int dialogLineIndex);

        /**
        * <summary>Define what's the dialog line to be show for this index</summary>
        */
        public abstract DialogLineInfo GetDialogLine(int dialogLineIndex);
    }
}
