using UnityEngine;

namespace Dialog
{
    public class AnswerController : MonoBehaviour
    {
        [SerializeField]
        private DialogManager dialogManager;

        public void OnOptionPicked(int index)
        {
            dialogManager.OnDialogOptionPicked(index);
            dialogManager.HideDialogBox();
            dialogManager.dialogBox.answersDialogBox.OnDone();
        }
    }
}
