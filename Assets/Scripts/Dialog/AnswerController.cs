using UnityEngine;

namespace Dialog
{
    public class AnswerController : MonoBehaviour
    {
        public DialogManager dialogManager;

        public void OnOptionAPicked()
        {
            dialogManager.OnDialogOptionPicked(0);
            dialogManager.HideDialogBox();
            dialogManager.dialogBox.answersDialogBox.OnDone();
        }

        public void OnOptionBPicked()
        {
            dialogManager.OnDialogOptionPicked(1);
            dialogManager.HideDialogBox();
            dialogManager.dialogBox.answersDialogBox.OnDone();
        }
        
        public void OnOptionCPicked()
        {
            dialogManager.OnDialogOptionPicked(2);
            dialogManager.HideDialogBox();
            dialogManager.dialogBox.answersDialogBox.OnDone();
        
        }
        
        public void OnOptionDPicked()
        {
            dialogManager.OnDialogOptionPicked(3);
            dialogManager.HideDialogBox();
            dialogManager.dialogBox.answersDialogBox.OnDone();   
        }
    }
}
