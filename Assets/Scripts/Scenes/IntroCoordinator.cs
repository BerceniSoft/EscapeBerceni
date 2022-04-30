using System;
using Dialog;
using UnityEngine;

namespace Scenes
{
    public class IntroCoordinator : MonoBehaviour
    {
        [SerializeField]
        private DialogManager dialogManager;

        private void Start()
        {
            ShowDialog();
        }

        private void ShowDialog()
        {
            print(dialogManager.currentDialogLineIndex);
            if (dialogManager.currentDialogLineIndex < dialogManager.dialogTree.DialogLineInfos.Length)
            {
                dialogManager.ShowDialog(ShowDialog);
            }
        }
    }
}
